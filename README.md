# extend.io
_A silly collection of scripts_

## GreaseMonkey / TamperMonkey Scripts

### Installation

_There is a lot of information [here](https://greasyfork.org/en), [here](https://www.userscript.zone/howto), [there](https://openuserjs.org/), [here also](https://gist.github.com/search?l=JavaScript&o=desc&q=%22%3D%3DUserScript%3D%3D%22&s=updated), [maybe here](https://www.tampermonkey.net/scripts.php) and definitely [here](https://www.google.com)_

--------------------

### Slinky

_TamperMonkey script that adds an item in context-menu (right click menu) for easier search_

_**AnythingGoogleSlinky.user.js** is provided as an example for a script that adds an option to search for **Anything** on **Google** under the TamperMonkey submenu_

_When clicked, it will get the text that is currently selected and join it with the rest of the url in the format of:_

    https://www.google.com/search?q= + selectedtext 
    
_and open the joined url in a new tab_

_Besides the example script there is also a "factory" script that generates a custom TamperMonkey script_

----

#### Planned Changes

- Add script for GreaseMonkey (It was made for it originally)

- Increase functionality

  * Add the option for menu items name to reflect: Search for **selected text** on **search name**

- Add more factory scripts
