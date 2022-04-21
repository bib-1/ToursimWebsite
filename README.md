# ToursimWebsite

Authentication:

Authentication is the process of determining the user’s identity via the available credentials, 
thus verifying the identity. In this web app user must be authenticated to open some of the links and add data.
Here unique email and password is used for establishing identity using Login.cshtml.cs controller 
and Register.cshtml.cs is used for validating that identity to provide authorization.

Authorization:
Authorization, meanwhile, is the process of providing permission to access the system. 
This website has implemented single factor authentication (using email and password only) 
to grant access to some of the controllers (all create methods) and to show the booking and roles link. 

Authorized Controllers:
Every Controllers in the web app are authorized (either fully or partially)

Hidden Link:
Booking and Roles are hidden. Only appears after login.

Database Used in the web app:

 
![image](https://user-images.githubusercontent.com/65732044/164362059-421dfb94-3474-4819-8170-e8dab5c7e13e.png)
