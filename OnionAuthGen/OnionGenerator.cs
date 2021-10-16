using System;
using X25519;

namespace OnionAuthGen
{
    /// <summary>
    /// Generates server and client authentication lines
    /// </summary>
    public static class OnionGenerator
    {
        /// <summary>
        /// Name of the directory that normally holds tor server auth key files
        /// </summary>
        public const string SERVER_DIR = "authorized_clients";
        /// <summary>
        /// File extension for server side key files
        /// </summary>
        public const string SERVER_FILE_EXT = ".auth";
        /// <summary>
        /// File extension for client side key files
        /// </summary>
        public const string CLIENT_FILE_EXT = ".auth_private";

        /// <summary>
        /// Authentication types supported by Tor
        /// </summary>
        public enum AuthenticationType { descriptor }
        /// <summary>
        /// Key types supported by Tor
        /// </summary>
        public enum KeyType { x25519 }

        /// <summary>
        /// Checks if the supplied string is a valid v3 onion domain
        /// </summary>
        /// <param name="OnionName">v3 onion name</param>
        /// <returns>true, if valid</returns>
        /// <remarks>The ".onion" suffix is optional</remarks>
        public static bool IsOnionName(string OnionName)
        {
            if (string.IsNullOrEmpty(OnionName))
            {
                return false;
            }
            if (OnionName.ToLower().EndsWith(".onion"))
            {
                OnionName = OnionName.Substring(0, OnionName.Length - 6);
            }
            if (OnionName.Length != 56 || !Base32.IsBase32(OnionName))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Generates an authentication key pair for Tor v3 services using common auth and key values
        /// </summary>
        /// <param name="OnionName">Onion name (with or without .onion suffix)</param>
        /// <returns>Key pair lines</returns>
        public static OnionDetails GenerateAuthentication(string OnionName)
        {
            return GenerateAuthentication(OnionName, AuthenticationType.descriptor, KeyType.x25519);
        }

        /// <summary>
        /// Generates an authentication key pair for Tor v3 services
        /// </summary>
        /// <param name="OnionName">Onion name (with or without .onion suffix)</param>
        /// <param name="AuthType">Service authentication type</param>
        /// <param name="Algorithm">Service algorithm</param>
        /// <returns>Key pair lines</returns>
        public static OnionDetails GenerateAuthentication(string OnionName, AuthenticationType AuthType, KeyType Algorithm)
        {
            ValidateEnum(AuthType, nameof(AuthType));
            ValidateEnum(Algorithm, nameof(Algorithm));

            var Keys = X25519KeyAgreement.GenerateKeyPair();
            return new OnionDetails()
            {
                RawKeys = Keys,
                Server = GenerateServerLine(Keys.PublicKey, AuthType, Algorithm),
                Client = GenerateClientLine(OnionName, Keys.PrivateKey, AuthType, Algorithm)
            };
        }

        /// <summary>
        /// Generates the server side line for a public key
        /// </summary>
        /// <param name="PublicKey">Public key</param>
        /// <param name="AuthType">Authentication type</param>
        /// <param name="Algorithm">Authentication algorithm</param>
        /// <returns>Server side authentication line</returns>
        /// <remarks>Make sure you use the *PUBLIC* key.</remarks>
        public static string GenerateServerLine(byte[] PublicKey, AuthenticationType AuthType, KeyType Algorithm)
        {
            if (PublicKey == null)
            {
                throw new ArgumentNullException(nameof(PublicKey));
            }
            if (PublicKey.Length != 32)
            {
                throw new FormatException("Key must be 32 bytes");
            }
            ValidateEnum(AuthType, nameof(AuthType));
            ValidateEnum(Algorithm, nameof(Algorithm));

            return string.Format("{0}:{1}:{2}",
                AuthType,
                Algorithm,
                Base32.Encode(PublicKey).ToUpper().TrimEnd('=')
            );
        }

        /// <summary>
        /// Generates the client side line for a public key
        /// </summary>
        /// <param name="OnionName">Onion name (with or without .onion suffix)</param>
        /// <param name="PrivateKey">Private key</param>
        /// <param name="AuthType">Authentication type</param>
        /// <param name="Algorithm">Authentication algorithm</param>
        /// <returns>Client side authentication line</returns>
        /// <remarks>Make sure you use the *PRIVATE* key.</remarks>
        public static string GenerateClientLine(string OnionName, byte[] PrivateKey, AuthenticationType AuthType, KeyType Algorithm)
        {
            if (OnionName == null)
            {
                throw new ArgumentNullException(nameof(OnionName));
            }
            if (PrivateKey == null)
            {
                throw new ArgumentNullException(nameof(PrivateKey));
            }
            if (PrivateKey.Length != 32)
            {
                throw new FormatException("Key must be 32 bytes");
            }

            if (OnionName.ToLower().EndsWith(".onion"))
            {
                OnionName = OnionName.Substring(0, OnionName.Length - 6);
            }
            if (OnionName.Length != 56 || !Base32.IsBase32(OnionName))
            {
                throw new FormatException("Parameter must be v3 onion name with or without \".onion\"");
            }
            ValidateEnum(AuthType, nameof(AuthType));
            ValidateEnum(Algorithm, nameof(Algorithm));

            return string.Format("{0}:{1}:{2}:{3}",
                OnionName.ToLower(),
                AuthType,
                Algorithm,
                Base32.Encode(PrivateKey).ToUpper().TrimEnd('=')
            );
        }

        /// <summary>
        /// Generates fully popuulated <see cref="OnionDetails"/> from <paramref name="ClientLine"/>
        /// </summary>
        /// <param name="ClientLine">Client private key file line</param>
        /// <returns>Populated <see cref="OnionDetails"/></returns>
        public static OnionDetails GenerateFromClientLine(string ClientLine)
        {
            if (ClientLine is null)
            {
                throw new ArgumentNullException(nameof(ClientLine));
            }
            var Segments = ClientLine.Split(':');
            if (Segments.Length != 4)
            {
                throw new FormatException(nameof(ClientLine) + " invalid. Not consisting of 4 parts");
            }
            if (!IsOnionName(Segments[0]))
            {
                throw new FormatException(nameof(ClientLine) + " invalid. Invalid onion name");
            }
            if (!Enum.TryParse(Segments[1], out AuthenticationType AT))
            {
                throw new FormatException(nameof(ClientLine) + " invalid. Unknown authentication type: " + Segments[1]);
            }
            if (!Enum.TryParse(Segments[2], out KeyType KT))
            {
                throw new FormatException(nameof(ClientLine) + " invalid. Unknown key type: " + Segments[2]);
            }
            var Ret = new OnionDetails();
            try
            {
                Ret.RawKeys = X25519KeyAgreement.GenerateKeyFromPrivateKey(Base32.Decode(Segments[3]));
                Ret.Client = ClientLine;
                Ret.Server = GenerateServerLine(Ret.RawKeys.PublicKey, AT, KT);
            }
            catch(Exception ex)
            {
                throw new FormatException(nameof(ClientLine) + " invalid. Invalid key: " + Segments[3], ex);
            }
            return Ret;
        }

        /// <summary>
        /// Checks if an enum value is defined. Throws an exception if it's not defined or not an enum type at all
        /// </summary>
        /// <param name="EnumValue">Enum value</param>
        /// <param name="ParamName">Original parameter name</param>
        /// <remarks>Throws on null</remarks>
        private static void ValidateEnum(object EnumValue, string ParamName)
        {
            if (EnumValue == null)
            {
                throw new ArgumentNullException(ParamName);
            }
            if (!EnumValue.GetType().IsEnum)
            {
                throw new ArgumentException($"'{ParamName}' is not an enum type");
            }
            if (!Enum.IsDefined(EnumValue.GetType(), EnumValue))
            {
                throw new ArgumentException($"'{ParamName}' is not a valid enum. Must be one of: " + string.Join(", ", Enum.GetNames(EnumValue.GetType())));
            }
        }
    }

    /// <summary>
    /// Provides key generation results
    /// </summary>
    public class OnionDetails
    {
        /// <summary>
        /// Raw keys
        /// </summary>
        public X25519KeyPair RawKeys { get; set; }
        /// <summary>
        /// Server side line
        /// </summary>
        public string Server { get; set; }
        /// <summary>
        /// Client side line
        /// </summary>
        public string Client { get; set; }
    }
}
