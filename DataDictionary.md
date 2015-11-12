﻿| Table          | PK/FK  | Field Name              | Type           | Unique | Nullable | Default Value | Reqd? | Notes                                                      |
|----------------|--------|-------------------------|----------------|--------|----------|---------------|-------|------------------------------------------------------------|
| Users          | PK     | Id                      | int            | Yes    | No       | AutoIncrement | Yes   |                                                            |
| Users          |        | Email                   | nvarchar(max)  | Yes    | No       |               | Yes   |                                                            |
| Users          |        | DisplayName             | nvarchar(50)   | Yes    | No       |               | Yes   |                                                            |
| Users          |        | Gender                  | char(1)        | No     | No       |               | Yes   |                                                            |
| Users          |        | FirstName               | nvarchar(50)   | No     | No       |               | Yes   |                                                            |
| Users          |        | LastName                | nvarchar(50)   | No     | No       |               | Yes   |                                                            |
| Users          |        | DateOfBirth             | dateTime       | No     | No       |               | Yes   |                                                            |
| Users          |        | DateOfRegistration      | dateTime       | No     | Yes      |               | Yes   | Generated by server                                        |
| Users          |        | PhoneNumber             | char(10)       | No     | No       |               | Yes   |                                                            |
| Employees      | PK     | Id                      | int            | Yes    | No       | AutoIncrement | Yes   |                                                            |
| Employees      | FK     | User_Id                 | int            | Yes    | No       |               | Yes   | ID from User Table                                         |
| Members        | PK     | Id                      | int            | Yes    | No       | AutoIncrement | Yes   |                                                            |
| Members        |        | IsEmailVerified         | boolean        | No     | No       |               | Yes   | Generated by server                                        |
| Members        |        | IsEmailMarketingAllowed | boolean        | No     | No       |               | Yes   |                                                            |
| Members        |        | StripeId                | int            | No     | No       |               | Yes   |                                                            |
| Members        | FK     | User_Id                 | int            | Yes    | No       |               | Yes   | ID from User Table                                         |
| Friendships    | PK, FK | Friendee_ID             | int            | No     | No       |               | Yes   | ID from User Table of request sender                       |
| Friendships    | PK, FK | Friender_ID             | int            | No     | No       |               | Yes   | ID from User Table of request recipient                    |
| Friendships    |        | isFamilyMember          | bool           | No     | No       |               | Yes   |                                                            |
| Friendships    |        | isAccepted              | bool           | No     | No       | FALSE         | Yes   |                                                            |
| Events         |        | Id                      | int            | Yes    | No       |               | Yes   |                                                            |
| Events         |        | Location                | nvarchar(2000) | No     | Yes      |               | Yes   |                                                            |
| Events         |        | StartDate               | dateTime       | No     | No       |               | Yes   |                                                            |
| Events         |        | EndDate                 | dateTime       | No     | No       |               | Yes   |                                                            |
| Events         |        | Description             | nvarchar(4000) | No     | Yes      |               | Yes   |                                                            |
| Events         | FK     | Employee_Id             | int            | No     | No       |               | Yes   | ID from Employee Table                                     |
| Events         |        | Capacity                | int            | No     | No       |               | Yes   |                                                            |
| Addresses      | PK     | Id                      | int            | Yes    | No       | AutoIncrement | Yes   |                                                            |
| Addresses      |        | StreetAddress           | nvarchar(255)  | No     | No       |               | Yes   |                                                            |
| Addresses      |        | City                    | nvarchar(50)   | No     | No       |               | Yes   |                                                            |
| Addresses      | FK     | Region                  | nvarchar(50)   | No     | No       |               |       |                                                            |
| Addresses      |        | Country                 | nvarchar(50)   | No     | No       |               | Yes   |                                                            |
| Addresses      |        | PostalCode              | char(5)        | No     | No       |               | Yes   |                                                            |
| Addresses      | FK     | MemberID                | int            | No     | No       |               | Yes   | ID from Member Table                                       |
| Orders         | PK     | Id                      | int            | Yes    | No       | AutoIncrement | Yes   |                                                            |
| Orders         |        | OrderPlacementDate      | dateTime       | No     | No       |               |       | System Generated DEFAULT( NOW ), Set at checkout           |
| Orders         |        | ShipDate                | dateTime       | No     | Yes      |               |       | Set at shipped                                             |
| Orders         |        | IsProcessed             | boolean        | No     | No       | FALSE         |       | Set after checkout                                         |
| Orders         | FK     | Approver_Id             | int            | No     | Yes      |               |       | ID from Employee Table, Set after checkout                 |
| Orders         | FK     | BillingAddress_Id       | int            | No     | Yes      |               | Yes   | ID from Address Table, Set after checkout                  |
| Orders         | FK     | Member_Id               | int            | No     | Yes      |               |       | ID from Member Table, Set after checkout                   |
| Orders         | FK     | ShippingAddress_Id      | int            | No     | Yes      |               | Yes   | ID from Address Table, Set after checkout                  |
| OrderItems     | FK     | Game_ID                 | int            | No     | No       |               | Yes   | ID from Game Table                                         |
| OrderItems     | FK     | Order_ID                | int            | No     | No       |               | Yes   | ID from Order Table                                        |
| OrderItems     |        | SalePrice               | decimal(18,2)  | No     | No       |               | Yes   | Canadian Dollars                                           |
| Games          | PK     | Id                      | int            | Yes    | No       | AutoIncrement | Yes   |                                                            |
| Games          |        | Name                    | nvarchar(max)  | No     | Yes      |               | Yes   |                                                            |
| Games          |        | ReleaseDate             | date           | No     | No       |               | Yes   |                                                            |
| Games          |        | SuggestedRetailPrice    | decimal(18,2)  | No     | No       |               | Yes   |                                                            |
| Games          | FK     | Platform_ID             | int            | No     | Yes      |               | Yes   | ID from Platform Table                                     |
| WishLists      | PK, FK | Member_Id               | int            | No     | No       |               | Yes   | ID from Member Table                                       |
| WishLists      | PK, FK | Game_Id                 | int            | No     | No       |               | Yes   | ID from Game Table                                         |
| Platforms      | PK     | Id                      | int            | Yes    | No       | AutoIncrement | Yes   |                                                            |
| Platforms      |        | Name                    | nvarchar(50)   | Yes    | No       |               | Yes   |                                                            |
| Categories     | PK     | Id                      | int            | Yes    | No       | AutoIncrement | Yes   |                                                            |
| Categories     |        | Name                    | nvarchar(max)  | Yes    | Yes      |               | Yes   |                                                            |
| GameCategories | FK     | Game_ID                 | int            | No     | No       |               | Yes   | ID from Game Table                                         |
| GameCategories | FK     | Category_Id             | int            | No     | No       |               | Yes   | ID from Category Table                                     |
| Reviews        | PK     | Id                      | int            | Yes    | No       | AutoIncrement | Yes   |                                                            |
| Reviews        |        | Rating                  | real           | No     | No       |               | Yes   |                                                            |
| Reviews        |        | Subject                 | nvarchar(500)  | No     | Yes      |               | Yes   | Null if just a rating                                      |
| Reviews        |        | Body                    | nvarchar(4000) | No     | Yes      |               | Yes   | Null if just a rating                                      |
| Reviews        | FK     | Approver_Id             | int            | No     | Yes      |               | Yes   | ID from Employee Table, Null if review is not yet assessed |
| Reviews        | FK     | Author_ID               | int            | No     | No       |               | Yes   | ID from Member Table                                       |
| Reviews        | FK     | Game_ID                 | int            | No     | No       |               | Yes   | ID from Game Table                                         |