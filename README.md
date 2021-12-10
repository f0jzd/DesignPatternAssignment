# DesignPatternAssignment

# MerchantStore

Objectpooling, Singleton, Observer

MerchantStore is using an object pool to create the inventory of the shop. I used an itemshop here since I planned on having the items used throughout whatever is being done in the game instead of keeping a refernce. Merchant store also has a singleton on it to make sure there is only one instance of it, but this also comes down to how it is used. It it will be used with different inventories throughout the same level, then the singleton should be removed. The merchantstore is also sending information with an observerpattern to the player inventory whenever the player spends money so it keeps a proper view of what is going on with the money.

# Inventory

Inventory is using the rest of the observer to keep a view of the money being spent in the players inventory. Here I wanted to implement an observerpattern to view changes done to the inventory, but then I had to change the list to an observable list from what I found online and since that could bring a lot of problems which I do not know how to solve I chose to do something else, and therefore used an observerpattern on the players money instead. This does not need to be an a list of subscriber but it also depends on the usage of it, what exactly is checking who the money value.
