# extend.io
_A silly collection of scripts_

## GreaseMonkey / TamperMonkey Scripts

### Installation

_There is a lot of information [here](https://greasyfork.org/en), [here](https://www.userscript.zone/howto), [there](https://openuserjs.org/), [here also](https://gist.github.com/search?l=JavaScript&o=desc&q=%22%3D%3DUserScript%3D%3D%22&s=updated), [maybe here](https://www.tampermonkey.net/scripts.php) and definitely [here](https://www.google.com)_

--------------------

### Slinky

_TamperMonkey script that adds an item in context-menu (right click menu) for easier search._

_**AnythingGoogleSlinky.user.js**_ is provided as an example for a script that adds an option to search for _**Anything**_ on _**Google**_ under the TamperMonkey submenu.

When clicked, it will get the text that is currently selected and join it with the rest of the url in the format of:

    https://www.google.com/search?q= + selectedtext 
    
and open the joined url in a new tab.

Besides the example script there is also a "factory" script that generates a custom TamperMonkey script.

----

#### Planned Changes

- Add script for GreaseMonkey (It was made for it originally)

- Increase functionality

  * Add the option for menu items name to reflect: Search for **selected text** on **search name**

- Add more factory scripts

--------------------

## Counter-Strike: Global Offensive Scripts

### Installation

- For _**scriptname**_**.nut** scripts
    
    * Copy the script file to 
    
            Counter-Strike Global Offensive\csgo\scripts\vscripts
            
    * Execute the script in the Developer Console using:
    
            script_execute scriptname
            
--------------------

### Jumpin' VAC Flash

_Squirrel script for calculating distance jumped, and displaying lenght in units, in chat._

#### Usage

 - Execute the script using:
 
        script_execute jjf
        script_execute PreJump()
        
 - You can create a custom bind to _"toggle"_ the script with:
 
        bind "keyname" "script TogglePause()"
        
   where _**keyname**_ equals to a keyboard key name. 
   
   _look into CS:GO cfg bindings for more information_
