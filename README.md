# RESUMBIT CHANGES

## SpellSpawner and SpellTest

This is a new attempt at making an object pool, for now it just spawns items from the pool in a fixed position, and then live for a fixed time, and then return. It has a limit of stored objects and if you are trying to spawn more than stored, it instatiates, but these are then destroyed rather than returned to keep the pool its original size.



# Design Patterns Assignment, Tomas Savela

This is only a collection of different systems where I attempted to use some pattern to the best of my knowledge.


## MerchantStore

Objectpooling, Singleton, Observer



MerchantStore is using an object pool to create the inventory of the shop. I used an itemshop here since I planned on having the items used throughout whatever is being done in the game instead of keeping a refernce. Merchant store also has a singleton on it to make sure there is only one instance of it, but this also comes down to how it is used. It it will be used with different inventories throughout the same level, then the singleton should be removed. The merchantstore is also sending information with an observerpattern to the player inventory whenever the player spends money so it keeps a proper view of what is going on with the money.

## Inventory

Observer

Inventory is using the rest of the observer to keep a view of the money being spent in the players inventory. Here I wanted to implement an observerpattern to view changes done to the inventory, but then I had to change the list to an observable list from what I found online and since that could bring a lot of problems which I do not know how to solve I chose to do something else, and therefore used an observerpattern on the players money instead. This does not need to be an a list of subscriber but it also depends on the usage of it, what exactly is checking who the money value.

Scripts used for the MerchantStore can be found in the Scripts/MerchantStore Folder of the project.



## Player Creator

Factory, State Machine

The player creator is just a factory, I wanted to implement a command pattern to make sure the player could change their choices, but I fell sick during the time of this assigment and had to make sure I reached the requirements for the assignment rather than doing something I wanted to do. The factory pattern also uses a statemachine to control what option is being chosen, it goes from first choosing name, to choosing race and finally class. Once all of those have been chosen it sends the values stored into the builder and creates the character. For now i am building the player every frame and was going to fix it but same as earlier, I fell sick and didnt get the time to fix it.

The only script this uses is the PlayerFactory, I could split it into different for clearer readability, this is something I need to get into the habit of doing. Currently I am afraid of making too many scripts versus creating to unclear scripts (This is most likely due to me being kind of new).

##Side Scroller

This is just something small I started and tried to get working, it uses a state machine to control the behaviour of the enemy, It first jumps around randomly, and if it spots the player it should start heading towards the player. This was all it did since I did not spend a lot of time on it. I also made a similar one that controlled the player movement, but it only debugs the current state of the player and does nothing more. 

Scripts used for the SideScroller can be found in the Scripts/StatePatterns Folder of the project.

