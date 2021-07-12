ShopBridge Project using Web API C#

Installing
Just clone the project and import it into your IDE also import the provided sql file(mysql) for the purpose of fetching items from database.

I am using postman to test API calls. Below are the end points for evry operations:

1. To get All Items
https://localhost:44373/Api/Product

2. Insert new Item. Add below JSON in body of the request
https://localhost:44373/Api/Product/POST
{
  "ItemID": 1,
  "ItemName": "xyz",
  "Description": "Dell i10",
  "price": 25000
}

3. Update the item. Add below JSON in body of the request
https://localhost:44373/Api/Product/Put
{
  "ItemID": 1,
  "ItemName": "xyz",
  "Description": "Dell i10",
  "price": 26000
}

4. Delete the item. Give the item id to be deleted in the url.
https://localhost:44373/Api/Product/Delete?itemid=10
