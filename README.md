WPFCalcule
===================

This project provides a discount calculator with two main features:

1.  Quantity-based discount: This feature calculates discounts based on a specific condition that is read from an Excel file. The discount is applied based on the quantity of items being purchased, and the discount amount is calculated according to the condition specified in the Json file.

2.  Currency converter and discount calculator: This feature allows the user to input prices in either US dollars or Lebanese pounds and then applies a discount based on the condition specified in the Json file. The user can select the currency type and enter the prices, and the application will convert the prices to the other currency before applying the discount.

Getting Started
---------------

To use the discount calculator, you will need to Json File ("db.json") on your computer. 

To run the application, simply open the solution file (`DiscountCalculator.sln`) in Visual Studio and run the project.

Usage
-----

Once the application is running, you can use the two features of the discount calculator:

### Quantity-based discount

1.  Enter the quantity of items being purchased in the `Quantity` field.
2.  The discount amount will be automatically calculated based on the condition specified in the `db.json` file.

### Currency converter and discount calculator

1.  Select the currency type from the drop-down menu.
2.  Enter the price of the item in the selected currency in the `Price` field.
3.  The price will be automatically get the discount amount will be applied based on the condition specified in the `db.json` file.
