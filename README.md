# LuxPower_Downloader
This is a tool to download the historic power data from the LuxPower website for your solar inverter.

In order to run this scrapper three details are required:

1. Username
2. Password
3. Station Number

In order to find the station number, one must log in to the LuxPower portal. 

The station number is in the top left hand corner as identified as the numbers in the red rectangle shown in the image below:

<img src="setup_images\station_number.png" alt="Select save directory" width="400"/>

All the files required to run the scrapper are included the scrapper can be exectued using the file in  `bin\Debug\LuxPower_Downloader.exe`

Once running this command prompt will appear:

<img src="setup_images\enter_login_info.png" alt="Enter Details" width="200"/>

Then a window will appear to select the save directory for the daily power record files:

<img src="setup_images\save_directory_select.png" alt="Select save directory" width="300"/>

Finally a chrome browser window will appear and begin to download the power record files.

## Notes ##

Currently the scrapper is set to download from the 2nd March 2019 but this can be adjusted in line 55 for the users needs
