# V3 Onion Authentication Generator

This application makes it easy for users to generate authentication keys for v3 onion services.
There's a help included in the application you can bring up by pressing `F1`

Common operations are described below.

The latest release can be downloaded from https://gitload.net/AyrA/OnionAuthGen

## Generating a New Key

1. Enter the onion name you want to create a key for
2. Click "Generate new keypair"
3. Click "Save" next to the client side key box and save the key to a file
4. Copy the server side key and send to the .onion operator

## Importing a Key

1. Click "import private key"
2. Select the private key you want to import
3. All fields will now be populated with matching information

## Changing Key Onion

Note: It's not recommended to use the same key for multiple services.
This feature is intended for when a service changes its onion name.

1. Import an existing key (see above)
2. Change the onion name
3. Confirm update prompt
4. Save key under new name
5. Restart Tor

Note Step 3: If you're not prompted to update the key, your onion name is likey invalid.
Check for leading or trailing whitespace. The name must be 56 characters. The ".onion" suffix is optional.
If you copied the onion from a web browser, you may get erxtra stuff like `http://`, which you need to delete.

Note Step 4: If you overwrite the existing key, Tor will no longer authenticate against the old onion.
Do that only if the old onion is no longer needed.

## Using a Key in Tor Browser

1. Import the required key as described above
2. Click "Copy key" next to the client key text box
3. Paste the key into Tor Browser
4. Confirm the alert box of the key generator to delete the key from the clibboard again

## Operating a .onion With Keys

1. Create a .onion service in the Tor configuration as described in the Tor manual
2. Restart Tor
3. The specified onion data directory now contains a folder "authorized_clients"
4. Save the server line you get from your users into that folder. The file name you chose must end in ".auth"
5. Restart Tor

Note: Tor will not scan the authorized_clients directory while it's running.
Every change you make requires a Tor service restart.

## Using Keys in Other Applications

1. Import the required key as described above
2. Copy the `ClientOnionAuthDir` line below the client key box
3. Insert the line into your local Tor client configuration file (usually called `torrc`)
4. Restart your Tor client

Your Tor client should now automatically authenticate with matching keys.
Every change to the key file directory you make requires a Tor service restart.
