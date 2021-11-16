# V3 Onion Authentication Generator

This application makes it easy for users to generate authentication keys for v3 onion services.

The latest release can be downloaded from https://gitload.net/AyrA/OnionAuthGen

A web browser based solution also exists:

- (regular web browser) https://cable.ayra.ch/tor/keygen/
- (Tor browser / hidden service) http://ocun3aeqaqdgng6wruvtl2egv4dc6ceesbnvbf7xi3pbxgh2jkzno6id.onion/

## Usage Help

There's a help included in the application you can bring up by pressing `F1`.
The help defaults to the currently used function but you can switch topics on the left.

## Default Key Directory

The application stores your private keys by default under `%USERPROFILE%\tor_auth`
but the directory can be changed at runtime in the "Private keys" tab.

There's no default for public keys because this depends on your Tor configuration.

## Using a Key in Tor Browser

1. Right click on the appropriate key in the "Private Keys" list
2. Select `Copy >> Private >> Key Only` from the menu
3. Paste the key into Tor Browser
4. Consider copying a different text to overwrite the clipboard

## Using Keys in Other Applications

1. Store all your private keys in a directory of your choice (also see "Default Key Directory" above)
2. Add the line `ClientOnionAuthDir C:\Path\To\Your\Tor\Keys` to your Tor client configuration (usually called `torrc`)
3. Restart your Tor client

Your Tor client should now automatically authenticate with matching keys.
Every change to the key file directory you make requires a Tor service restart.

## Operating a .onion With Keys

1. Create a .onion service in the Tor configuration as described in the Tor manual
2. Restart Tor
3. The specified onion data directory now contains a folder "authorized_clients"
4. Save the server line you get from your users into that folder. The file name you chose must end in ".auth"
5. Restart Tor

Note: Tor will not scan the authorized_clients directory while it's running.
Every change you make requires a Tor service restart.
