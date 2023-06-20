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
