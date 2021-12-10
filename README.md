# DesignPatternAssignment

# MerchantStore

MerchantStore is using an object pool to create the inventory of the shop. I used an itemshop here since I planned on having the items used throughout whatever is being done in the game instead of keeping a refernce. Merchant store also has a singleton on it to make sure there is only one instance of it, but this also comes down to how it is used. It it will be used with different inventories throughout the same level, then the singleton should be removed. The merchantstore is also sending information with an observerpattern to the player inventory whenever the player spends money so it keeps a proper view of what is going on with the money.
