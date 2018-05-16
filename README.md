# THS Discord Blocker
Blocks Discord from opening while connected to the `THS-Students` network

## How it works
The blocker service will run on startup along with all your startup apps, usually after Discord runs. The service uses the ManagedWifi (https://archive.codeplex.com/?p=managedwifi) library to detect the connected Wifi network SSID. If the `THS-Students` network is connected to, it will check for the Discord process. If it is found, it will be killed and you will be notified. If the network is not found, the service will start Discord (not if it is already open).


