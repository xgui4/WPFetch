# WPFetch

## The installer is still a prototype and might not work proprely due to being still a test so do not use the installer on a production machine

## Warning : This project is a hobby project and may be one day stopped being updated and isnt covered by any warranty

## Summary 
A utility to fetch you system info with a OS-tan

## Features
- Fetch you hardware like noefetch does but with a GUI and with customisable main image 
- Show OS-Tan as main images and windows logo on top on of the setup info
- Command line argurment
- Configuration via GUI (comming soon)
- Link for a the github release page in the check update button (might do more in the future)

## Nuget Packages && Framework used :
- Community Toolkit  Version 8.4.0
- FluentSysInfo.Core Version 1.0.8860
- Newtonsoft.Json Version 13.0.3
- System.Drawing.Common Version 9.0.0
- System.Management Version 9.0.0
- Windows Presentation Foundation
- Inno Setup for the installer 

## Compilation and installation 

- Option 1 : compiler from source         
    1. dotnet publish with the right arch (X86 or X86-64 are officially supported) 

    (Install the app) 

    2. Open the installer script file in inno setup for the desirable architecture
    3. Compile the installer
    4. Open the installer as admin (if you run it as a normal user, it will not install correctly)
    5. Reboot the computer when installer have finished (required to register the app for cmd.exe)   
    6. You are now done ! 
    
    (Create portable app)

    2. Move the folder of the distribution to the desirable path
    3. App the bin path to the path (tutorial : https://windowsloop.com/how-to-add-to-windows-path/)
    4. Confirm the change, try in a new cmd prompt, if it doesn work try to reboot
    5. You are now done ! 

- Option 2 : use the "stable" installer file from github page 
    1. Open the installer as admin (if you run it as a normal user, it will not install correctly)  
    2. Reboot the computer when installer have finished (required to register the app for cmd.exe)
    3. You are now done ! 

- Option 3 : download the portable app (.zip)
    1. download the .zip file 
    2. unzip the folder to the desirable path 
    3. App the bin path to the path (tutorial : https://windowsloop.com/how-to-add-to-windows-path/)
    4. Confirm the change, try in a new cmd prompt, if it doesn work try to reboot
    5. You are now done ! 

## License 
MIT

## Image Credits
- App icon : https://www.reddit.com/r/MadobeNanami/comments/1hn9nlo/nanami_and_c_sharp/
- Windows logo (Own by Microsoft Corporation) image available on Wikipedia
  - Windows 11 : https://en.wikipedia.org/wiki/Windows_11#/media/File:Windows_11_logo.svg/2
  - Windows 10 : https://en.wikipedia.org/wiki/Windows_10#/media/File:Windows_10_Logo.svg/2
  - Windows 8 : https://en.wikipedia.org/wiki/Windows_8#/media/File:Windows_8_logo_and_wordmark.svg/2
  - Windows 7 : https://en.wikipedia.org/wiki/Windows_7#/media/File:Windows_7_Logo_and_Wordmark.svg
  - Windows Vista : https://en.wikipedia.org/wiki/Windows_Vista#/media/File:Windows_Vista_Logo_and_Wordmark.svg
  - Windows XP : https://en.wikipedia.org/wiki/Windows_XP#/media/File:Windows_XP_logo_and_wordmark.svg
  - Windows Me : https://en.wikipedia.org/wiki/Windows_Me#/media/File:Microsoft_Windows_Millenium_Edition_Logo.svg
  - Windows 2000 : https://en.wikipedia.org/wiki/Windows_2000#/media/File:Windows_2000_logo.svg
  - Windows 98 : https://en.wikipedia.org/wiki/Windows_98#/media/File:Microsoft_Windows_98_logo_with_wordmark.svg
  - Windows 95 : https://en.wikipedia.org/wiki/Windows_95#/media/File:Microsoft_Windows_95_logo_with_wordmark.svg
  - Windows 3.1 : https://en.wikipedia.org/wiki/Windows_3.1#/media/File:Microsoft_Windows_3.1x_logo_with_wordmark.svg
  - Windows 3.0 : https://en.wikipedia.org/wiki/Windows_3.0#/media/File:Windows_logo_and_wordmark_-_1990.svg
  - Windows 1.0 To 2.0 : https://en.wikipedia.org/wiki/Windows_2.1#/media/File:Windows_logo_and_wordmark_-_(1985-1989).svg
  - Windows 3X NT : https://en.wikipedia.org/wiki/Windows_NT_3.1#/media/File:Microsoft_Windows_NT_3.1_logo_with_wordmark.svg
  - Windows 4+ NT : https://en.wikipedia.org/wiki/Windows_NT_4.0#/media/File:Windows_NT_logo.svg
- List of OS-Tan (Most of these of fanmade)
    - OS-Tan Windows 1.0 : https://www.ostan-collections.net/wiki/index.php/File:Windows1avi.png
    - OS-Tan.Windows 2.0 : https://www.ostan-collections.net/wiki/index.php/File:Windows2avi.png
    - OS-Tan Windows 3.1 : https://www.ostan-collections.net/wiki/index.php/File:Win3-1.jpg
    - OS-Tan Windows NT : https://www.ostan-collections.net/wiki/index.php/File:WinNTtan.jpg
    - OS-Tan Windows 95 : https://www.ostan-collections.net/wiki/index.php/File:95-tan2.jpg?20120630044724
    - OS-Tan Windows 97 : https://www.ostan-collections.net/wiki/index.php/File:Win97tan.jpg?20110501013251
    - OS-Tan Windows 98SE : https://www.ostan-collections.net/wiki/index.php/File:98SEtan.jpg
    - OS-Tan Windows 98 : https://www.ostan-collections.net/wiki/index.php/File:Win98tan.jpg
    - OS-Tan Microsoft Neptune : https://www.ostan-collections.net/wiki/index.php/File:Neptune.gif
    - OS-Tan Windows Odyssey : https://www.ostan-collections.net/wiki/index.php/File:Odyssey.gif
    - OS-Tan Windows Me : https://www.ostan-collections.net/wiki/index.php/File:Winme.jpg
    - OS-Tan Windows 2000 : https://www.ostan-collections.net/wiki/index.php/File:Win2K.jpg
    - OS-Tan Windows XP : https://in.pinterest.com/pin/900157044269294388/
    - OS-Tan Windows Longhorn : https://neuro.nya.pub/fun/ostan/
    - OS-Tan Windows Vista : https://www.ostan-collections.net/wiki/index.php/File:Schoolgirlvistan.jpg
    - OS-Tan Windows Server 2003 : https://www.ostan-collections.net/wiki/index.php/File:WinServer2003tan.jpg
    - OS-Tan Windows Server 2008 : https://www.ostan-collections.net/wiki/index.php/File:Saba-fish.jpg
    - OS-Tan Windows 7 : https://www.reddit.com/r/MadobeNanami/comments/1hn9nlo/nanami_and_c_sharp/
    - OS-Tan Windows 8 : https://www.ostan-collections.net/wiki/index.php/File:Yuai.png
    - OS-Tan Windows 10 : https://www.ostan-collections.net/wiki/index.php/File:10-full_promo.png
    - OS-Tan Windows 11 :  https://www.reddit.com/r/OStan/comments/170ldzu/my_ostan_for_windows_11_koemi_madobe_today_is_its/
    - OS-Tan Windows 11 (Alternatif) : https://www.reddit.com/r/OStan/comments/11vl35o/fanart_ichika_madobe_mascot_windows_11/

## Legal disclaimer :
This product isn't a official product by Microsoft and isn't affliated (and never will) by them.
