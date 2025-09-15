# Notepad++ Reds Plugin
Simple Notepad++ plugin for view your keys and data from Redis.

# Usage
1. Find Redis in the plugin menu:
![](/Images/Menu.png)
2. Open settings file
3. Insert your Redis default server<br>
RedisDefaultServer=YOUR_SERVER<br>
Save and close Notepad++
4. Restart Notepad++ 
5. Click in the menu Redis --> Show dialog    
6. Plugin dialog appears<br>
    ![](/Images/Dialog.png)
    Check if Server Redis textbox is compiled with your server <code>Point 3</code>
7. Click on Connect<br>
    Your keys should appear 
8. Click on a key and click Load<br>
    Your key value open in a new file

    

## Thanks to
[StackExchange.Redis](https://github.com/StackExchange/StackExchange.Redis)<br>
[Npp.DotNet.Plugin](https://github.com/npp-dotnet/Npp.DotNet.Plugin)