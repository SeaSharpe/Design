# Threat Modeling Report
## Created on 2015-11-10 5:48:35 PM

**Threat Model Name:** Conestoga VideoGame Store Threat Model

**Owner:** Sea Sharpe

**Reviewer:** Dan Hofstede

**Contributors:** John Steel

**Description:** This service allows customers to purchase and review
games, create wish lists and track game-related events.

**Assumptions:** We assume that it is in Stripe's interests to provide a
stable, secure service with minimal downtime.

**External Dependencies:** Stripe's Credit Card Payment Service



### Threat Model Summary: 
|                          |      |
| ------------------------ | ---- |
| Not Started              | 0    |
| Not Applicable           | 8    |
| Needs Investigation      | 0    |
| Mitigation Implemented   | 37   |
| Total                    | 45   |
| Total Migrated           | 0    |
|                          |      |

------------------------------------------------------------------------

Diagram: Diagram 1 
------------------

![Diagram 1 diagram screenshot](https://cloud.githubusercontent.com/assets/3138467/11080584/49606ef4-87e3-11e5-8467-c02e170a7f5b.png)

### Diagram 1 Diagram Summary: 

  ------------------------ ----
  Not Started              0
  Not Applicable           8
  Needs Investigation      0
  Mitigation Implemented   37
  Total                    45
  Total Migrated           0
  ------------------------ ----

### Interaction: HTTPS 

![HTTPS interaction screenshot](https://cloud.githubusercontent.com/assets/3138467/11080604/852ca6a0-87e3-11e5-8bc2-ad5a9a7b6daf.png)



#### 1. Browser Client Process Memory Tampered  [State: Mitigation Implemented]  [Priority: High]  

  -------------------- ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
  **Category:**        Tampering

  **Description:**     If Browser Client is given access to memory, such as shared memory or pointers, or is given the ability to control what Stripe Web Service executes (for example, passing back a function pointer.), then Browser Client can tamper with Stripe Web Service. Consider if the function could work with less access to memory, such as passing data rather than pointers. Copy in data provided, and then validate it.

  **Justification:**   The Stripe web service is not under our control and the only information that could be compromised in such an event is the customer's information. If the customer's computer was already compromised their keystrokes may already have been logged. We cannot help the customer in such a situation.
  -------------------- ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------





#### 2. Elevation Using Impersonation  [State: Mitigation Implemented]  [Priority: High]  

  -------------------- ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
  **Category:**        Elevation Of Privilege

  **Description:**     Stripe Web Service may be able to impersonate the context of Browser Client in order to gain additional privilege.

  **Justification:**   Stripe would only be able to gain the privilege of an account that it has the credentials for. In our scenario, stripe already stores the most crucial information for our users, their credit card information.
  -------------------- ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------





### Interaction: HTTPS 

![HTTPS interaction screenshot](https://cloud.githubusercontent.com/assets/3138467/11080667/0cccbd98-87e4-11e5-8e7e-24a33796b064.png)



#### 3. Stripe Web Service Process Memory Tampered  [State: Mitigation Implemented]  [Priority: High]  

  -------------------- ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
  **Category:**        Tampering

  **Description:**     If Stripe Web Service is given access to memory, such as shared memory or pointers, or is given the ability to control what Browser Client executes (for example, passing back a function pointer.), then Stripe Web Service can tamper with Browser Client. Consider if the function could work with less access to memory, such as passing data rather than pointers. Copy in data provided, and then validate it.

  **Justification:**   We have to trust Stripe not to do this.
  -------------------- ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------





#### 4. Elevation Using Impersonation  [State: Mitigation Implemented]  [Priority: High]  

  -------------------- ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
  **Category:**        Elevation Of Privilege

  **Description:**     Browser Client may be able to impersonate the context of Stripe Web Service in order to gain additional privilege.

  **Justification:**   Client cannot impersonate stripe without knowledge of their Certificate Private Key. We trust that stripe's private key stays private. Should it be stolen we trust that stripe would revoke their certificate to prevent this kind of attack.
  -------------------- ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------





### Interaction: HTTPS 

![HTTPS interaction screenshot](https://cloud.githubusercontent.com/assets/3138467/11080674/2993bb70-87e4-11e5-8e0b-1610fce9e33e.png)




#### 5. Spoofing the Stripe Web Service Process  [State: Mitigation Implemented]  [Priority: High]  

  -------------------- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
  **Category:**        Spoofing

  **Description:**     Stripe Web Service may be spoofed by an attacker and this may lead to unauthorized access to Web Server. Consider using a standard authentication mechanism to identify the source process.

  **Justification:**   Stripe is identified by it's HTTPs certificate.
  -------------------- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------





#### 6. Cross Site Scripting  [State: Mitigation Implemented]  [Priority: High]  

  -------------------- ------------------------------------------------------------------------------------------------------------------------------------------------
  **Category:**        Tampering

  **Description:**     The web server 'Web Server' could be a subject to a cross-site scripting attack because it does not sanitize untrusted input.

  **Justification:**   Sanitization is handled by the Razor 5 and Entity frameworks, even so, tests will be done to ensure this. See Github Implementation Issue \#1.
  -------------------- ------------------------------------------------------------------------------------------------------------------------------------------------





#### 7. Potential Data Repudiation by Web Server  [State: Mitigation Implemented]  [Priority: High]  

  -------------------- -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
  **Category:**        Repudiation

  **Description:**     Web Server claims that it did not receive data from a source outside the trust boundary. Consider using logging or auditing to record the source, time, and summary of the received data.

  **Justification:**   IIS Access logs will configured to include this information.
  -------------------- -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------





#### 8. Potential Process Crash or Stop for Web Server  [State: Not Applicable]  [Priority: High]  

  -------------------- -------------------------------------------------------------------------------------------------
  **Category:**        Denial Of Service

  **Description:**     Web Server crashes, halts, stops or runs slowly; in all cases violating an availability metric.

  **Justification:**   Stripe does not rely on our web server to operate.
  -------------------- -------------------------------------------------------------------------------------------------





#### 9. Data Flow HTTPS Is Potentially Interrupted  [State: Mitigation Implemented]  [Priority: High]  

  -------------------- --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
  **Category:**        Denial Of Service

  **Description:**     An external agent interrupts data flowing across a trust boundary in either direction.

  **Justification:**   If an ISP, government or other entity disrupts traffic between our server and clients or stripe we would no longer be able to process sales. We would take all aproprate steps to ensure that this does not occur.
  -------------------- --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------





#### 10. Elevation Using Impersonation  [State: Mitigation Implemented]  [Priority: High]  

  -------------------- -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
  **Category:**        Elevation Of Privilege

  **Description:**     Web Server may be able to impersonate the context of Stripe Web Service in order to gain additional privilege.

  **Justification:**   We use stripe so that we don't have to store credit card information on our systems, but the web server could pretend to be stripe (or just be patched to work without stripe) and customer credit card information could be captured. This could do signifigant harm to our brand if it was discovered. Precautions will be taken to ensure that this does not happen.
  -------------------- -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------





#### 11. Web Server May be Subject to Elevation of Privilege Using Remote Code Execution  [State: Mitigation Implemented]  [Priority: High]  

  -------------------- --------------------------------------------------------------------------------------------------------------------------
  **Category:**        Elevation Of Privilege

  **Description:**     Stripe Web Service may be able to remotely execute code for Web Server.

  **Justification:**   We will sanitize inputs from Stripe and throw exceptions/log errors when unexpected values are received.
  -------------------- --------------------------------------------------------------------------------------------------------------------------





#### 12. Elevation by Changing the Execution Flow in Web Server  [State: Mitigation Implemented]  [Priority: High]  

  -------------------- ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
  **Category:**        Elevation Of Privilege

  **Description:**     An attacker may pass data into Web Server in order to change the flow of program execution within Web Server to the attacker's choosing.

  **Justification:**   User inputs will inevitably effect the flow of our server software but we will ensure that there are not any implementation bugs where a user is able to take actions that they are not authorized to do.
  -------------------- ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------





### Interaction: HTTPS 

![HTTPS interaction screenshot](https://cloud.githubusercontent.com/assets/3138467/11080678/38d0f422-87e4-11e5-8824-aa01f0558457.png)



#### 13. Spoofing the Web Server Process  [State: Mitigation Implemented]  [Priority: High]  

  -------------------- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
  **Category:**        Spoofing

  **Description:**     Web Server may be spoofed by an attacker and this may lead to unauthorized access to Stripe Web Service. Consider using a standard authentication mechanism to identify the source process.

  **Justification:**   Stripe provides credentials for the server, as long as those credentials are not leaked, the web service cannot be spoofed in this manner.
  -------------------- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------





#### 14. Web Server Process Memory Tampered  [State: Not Applicable]  [Priority: High]  

  -------------------- --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
  **Category:**        Tampering

  **Description:**     If Web Server is given access to memory, such as shared memory or pointers, or is given the ability to control what Stripe Web Service executes (for example, passing back a function pointer.), then Web Server can tamper with Stripe Web Service. Consider if the function could work with less access to memory, such as passing data rather than pointers. Copy in data provided, and then validate it.

  **Justification:**   Web Server is on a private server and does not share memory.
  -------------------- --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------





#### 15. Potential Data Repudiation by Stripe Web Service  [State: Not Applicable]  [Priority: High]  

  -------------------- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
  **Category:**        Repudiation

  **Description:**     Stripe Web Service claims that it did not receive data from a source outside the trust boundary. Consider using logging or auditing to record the source, time, and summary of the received data.

  **Justification:**   Out of Scope
  -------------------- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------





#### 16. Potential Process Crash or Stop for Stripe Web Service  [State: Mitigation Implemented]  [Priority: High]  

  -------------------- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
  **Category:**        Denial Of Service

  **Description:**     Stripe Web Service crashes, halts, stops or runs slowly; in all cases violating an availability metric.

  **Justification:**   If the Stripe service has issues, we will no longer be able to complete sales; however, we can still function as a social hub for game & event information. This issue could cost us revenue. We trust that to protect their brand name and minimize financial loss, Stripe will strive to keep their downtime to a minimum.
  -------------------- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------





#### 17. Data Flow HTTPS Is Potentially Interrupted  [State: Mitigation Implemented]  [Priority: High]  

  -------------------- --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
  **Category:**        Denial Of Service

  **Description:**     An external agent interrupts data flowing across a trust boundary in either direction.

  **Justification:**  If an ISP, government or other entity disrupts traffic between our server and clients or stripe we would no longer be able to process sales. We would take all aproprate steps to ensure that this does not occur.
  -------------------- --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------





#### 18. Elevation Using Impersonation  [State: Mitigation Implemented]  [Priority: High]  

  -------------------- ----------------------------------------------------------------------------------------------------------------------
  **Category:**        Elevation Of Privilege

  **Description:**     Stripe Web Service may be able to impersonate the context of Web Server in order to gain additional privilege.

  **Justification:**   The calls to and callbacks from stripe are too specific and should not lend themselves to elevation of privlege bugs
  -------------------- ----------------------------------------------------------------------------------------------------------------------





#### 19. Stripe Web Service May be Subject to Elevation of Privilege Using Remote Code Execution  [State: Not Applicable]  [Priority: High]  

  -------------------- -------------------------------------------------------------------------
  **Category:**        Elevation Of Privilege

  **Description:**     Web Server may be able to remotely execute code for Stripe Web Service.

  **Justification:**   Attacks against stripe from our server are out of scope.
  -------------------- -------------------------------------------------------------------------





#### 20. Elevation by Changing the Execution Flow in Stripe Web Service  [State: Not Applicable]  [Priority: High]  

  -------------------- ----------------------------------------------------------------------------------------------------------------------------------------------------------
  **Category:**        Elevation Of Privilege

  **Description:**     An attacker may pass data into Stripe Web Service in order to change the flow of program execution within Stripe Web Service to the attacker's choosing.

  **Justification:**   Attacks against stripe from our server are out of scope.
  -------------------- ----------------------------------------------------------------------------------------------------------------------------------------------------------





### Interaction: HTTPS 

![HTTPS interaction screenshot](https://cloud.githubusercontent.com/assets/3138467/11080682/4adab540-87e4-11e5-9152-6e6a7ff4f514.png)




#### 21. Spoofing of Destination Data Store SQL Database  [State: Mitigation Implemented]  [Priority: High]  

  -------------------- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
  **Category:**        Spoofing

  **Description:**     SQL Database may be spoofed by an attacker and this may lead to data being written to the attacker's target instead of SQL Database. Consider using a standard authentication mechanism to identify the destination data store.

  **Justification:**   SQL Database will be authenticated using mutual SSL Authentication. So long as its private key stays private, they will be authentic.
  -------------------- ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------





#### 22. Potential SQL Injection Vulnerability for SQL Database  [State: Mitigation Implemented]  [Priority: High]  

  -------------------- ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
  **Category:**        Tampering

  **Description:**     SQL injection is an attack in which malicious code is inserted into strings that are later passed to an instance of SQL Server for parsing and execution. Any procedure that constructs SQL statements should be reviewed for injection vulnerabilities because SQL Server will execute all syntactically valid queries that it receives. Even parameterized data can be manipulated by a skilled and determined attacker.

  **Justification:**   Sanitization is handled by the Razor 5 and Entity frameworks, even so, tests will be done to ensure this. See Github Implementation Issue \#1.
  -------------------- ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------





#### 23. Weak Credential Storage  [State: Mitigation Implemented]  [Priority: High]  

  -------------------- -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
  **Category:**        Information Disclosure

  **Description:**     Credentials held at the server are often disclosed or tampered with and credentials stored on the client are often stolen. For server side, consider storing a salted hash of the credentials instead of storing the credentials themselves. If this is not possible due to business requirements, be sure to encrypt the credentials before storage, using an SDL-approved mechanism. For client side, if storing credentials is required, encrypt them and protect the data store in which they're stored

  **Justification:**   We implement hashing and salting of user passwords. Actual passwords are never stored in logs or the db and are only in memory for as long as is required to hash them.
  -------------------- -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------





#### 24. Potential Excessive Resource Consumption for Web Server or SQL Database  [State: Mitigation Implemented]  [Priority: High]  

  -------------------- ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
  **Category:**        Denial Of Service

  **Description:**     Does Web Server or SQL Database take explicit steps to control resource consumption? Resource consumption attacks can be hard to deal with, and there are times that it makes sense to let the OS do the job. Be careful that your resource requests don't deadlock, and that they do timeout.

  **Justification:**   Auditing should be done on the most time consuming database tasks to find out if they are malicious. If so, steps should be taken to automatically ban or block users from creating malicious requests aimed at tying up resources.
  -------------------- ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------





### Interaction: HTTPS 

![HTTPS interaction screenshot](https://cloud.githubusercontent.com/assets/3138467/11080686/5f87ecec-87e4-11e5-831a-c1ef5ec869e4.png)




#### 25. Spoofing of Source Data Store SQL Database  [State: Mitigation Implemented]  [Priority: High]  

  -------------------- -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
  **Category:**        Spoofing

  **Description:**     SQL Database may be spoofed by an attacker and this may lead to incorrect data delivered to Web Server. Consider using a standard authentication mechanism to identify the source data store.

  **Justification:**   SQL Database will be authenticated using mutual SSL Authentication. So long as its private key remains private it can be assumed as authentic.
  -------------------- -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------





#### 26. Cross Site Scripting  [State: Mitigation Implemented]  [Priority: High]  

  -------------------- ------------------------------------------------------------------------------------------------------------------------------------------------
  **Category:**        Tampering

  **Description:**     The web server 'Web Server' could be a subject to a cross-site scripting attack because it does not sanitize untrusted input.

  **Justification:**   Sanitization is handled by the Razor 5 and Entity frameworks, even so, tests will be done to ensure this. See Github Implementation Issue \#1.
  -------------------- ------------------------------------------------------------------------------------------------------------------------------------------------





#### 27. Persistent Cross Site Scripting  [State: Mitigation Implemented]  [Priority: High]  

  -------------------- ----------------------------------------------------------------------------------------------------------------------------------------------------------------------
  **Category:**        Tampering

  **Description:**     The web server 'Web Server' could be a subject to a persistent cross-site scripting attack because it does not sanitize data store 'SQL Database' inputs and output.

  **Justification:**   Sanitization is handled by the Razor 5 and Entity frameworks, even so, tests will be done to ensure this. See Github Implementation Issue \#1.
  -------------------- ----------------------------------------------------------------------------------------------------------------------------------------------------------------------





#### 28. Weak Access Control for a Resource  [State: Mitigation Implemented]  [Priority: High]  

  -------------------- ------------------------------------------------------------------------------------------------------------------------------------------------
  **Category:**        Information Disclosure

  **Description:**     Improper data protection of SQL Database can allow an attacker to read information not intended for disclosure. Review authorization settings.

  **Justification:**   Extra care will be taken to ensure that requests are authorized.
  -------------------- ------------------------------------------------------------------------------------------------------------------------------------------------





### Interaction: HTTPS 

![HTTPS interaction screenshot](https://cloud.githubusercontent.com/assets/3138467/11080693/6e54eb08-87e4-11e5-808b-3d101716570a.png)



#### 29. Spoofing the Browser Client Process  [State: Mitigation Implemented]  [Priority: High]  

  -------------------- -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
  **Category:**        Spoofing

  **Description:**     Browser Client may be spoofed by an attacker and this may lead to unauthorized access to Web Server. Consider using a standard authentication mechanism to identify the source process.

  **Justification:**   A token stored in an HTTP cookie will be used to authenticate the client. Cookies will timeout periodically to mitigate the risk of being stolen.
  -------------------- -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------





#### 30. Cross Site Scripting  [State: Mitigation Implemented]  [Priority: High]  

  -------------------- ------------------------------------------------------------------------------------------------------------------------------------------------
  **Category:**        Tampering

  **Description:**     The web server 'Web Server' could be a subject to a cross-site scripting attack because it does not sanitize untrusted input.

  **Justification:**   Sanitization is handled by the Razor 5 and Entity frameworks, even so, tests will be done to ensure this. See Github Implementation Issue \#1.
  -------------------- ------------------------------------------------------------------------------------------------------------------------------------------------





#### 31. Potential Data Repudiation by Web Server  [State: Mitigation Implemented]  [Priority: High]  

  -------------------- -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
  **Category:**        Repudiation

  **Description:**     Web Server claims that it did not receive data from a source outside the trust boundary. Consider using logging or auditing to record the source, time, and summary of the received data.

  **Justification:**   IIS Access logs will configured to include this information.
  -------------------- -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------





#### 32. Potential Process Crash or Stop for Web Server  [State: Mitigation Implemented]  [Priority: High]  

  -------------------- ----------------------------------------------------------------------------------------------------
  **Category:**        Denial Of Service

  **Description:**     Web Server crashes, halts, stops or runs slowly; in all cases violating an availability metric.

  **Justification:**   Such problems would cost us business. We will ensure that our platform is as stable as possible.
  -------------------- ----------------------------------------------------------------------------------------------------





#### 33. Data Flow HTTPS Is Potentially Interrupted  [State: Mitigation Implemented]  [Priority: High]  

  -------------------- --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
  **Category:**        Denial Of Service

  **Description:**     An external agent interrupts data flowing across a trust boundary in either direction.

  **Justification:**   If an ISP, government or other entity disrupts traffic between our server and clients or stripe we would no longer be able to process sales. We would take all aproprate steps to ensure that this does not occur.
  -------------------- --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------





#### 34. Elevation Using Impersonation  [State: Not Applicable]  [Priority: High]  

  -------------------- ------------------------------------------------------------------------------------------------------------
  **Category:**        Elevation Of Privilege

  **Description:**     Web Server may be able to impersonate the context of Browser Client in order to gain additional privilege.

  **Justification:**   This does not apply in our case.
  -------------------- ------------------------------------------------------------------------------------------------------------





#### 35. Web Server May be Subject to Elevation of Privilege Using Remote Code Execution  [State: Mitigation Implemented]  [Priority: High]  

  -------------------- --------------------------------------------------------------------------------------------------------------------------------------------------------------------
  **Category:**        Elevation Of Privilege

  **Description:**     Browser Client may be able to remotely execute code for Web Server.

  **Justification:**   Rasor 5 should handle sanatization of all form inputs but testing should be done to verify that user inputs can never allow the user to compromise our web server.
  -------------------- --------------------------------------------------------------------------------------------------------------------------------------------------------------------





#### 36. Elevation by Changing the Execution Flow in Web Server  [State: Mitigation Implemented]  [Priority: High]  

  -------------------- ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
  **Category:**        Elevation Of Privilege

  **Description:**     An attacker may pass data into Web Server in order to change the flow of program execution within Web Server to the attacker's choosing.

  **Justification:**   User inputs will inevitably effect the flow of our server software but we will take care to ensure that there are not any implementation bugs where a user is able to take actions that they are not authorized to do.
  -------------------- ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------





#### 37. Cross Site Request Forgery  [State: Mitigation Implemented]  [Priority: High]  

  -------------------- ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
  **Category:**        Elevation Of Privilege

  **Description:**     Cross-site request forgery (CSRF or XSRF) is a type of attack in which an attacker forces a user's browser to make a forged request to a vulnerable site by exploiting an existing trust relationship between the browser and the vulnerable web site. In a simple scenario, a user is logged in to web site A using a cookie as a credential. The other browses to web site B. Web site B returns a page with a hidden form that posts to web site A. Since the browser will carry the user's cookie to web site A, web site B now can take any action on web site A, for example, adding an admin to an account. The attack can be used to exploit any requests that the browser automatically authenticates, e.g. by session cookie, integrated authentication, IP whitelisting, … The attack can be carried out in many ways such as by luring the victim to a site under control of the attacker, getting the user to click a link in a phishing email, or hacking a reputable web site that the victim will visit. The issue can only be resolved on the server side by requiring that all authenticated state-changing requests include an additional piece of secret payload (canary or CSRF token) which is known only to the legitimate web site and the browser and which is protected in transit through SSL/TLS. See the Forgery Protection property on the flow stencil for a list of mitigations.

  **Justification:**   Razor 5 has mitigated this with Anti-Forgery tokens. These can make testing with Curl / Postman difficult and may be turned off during development. We must ensure that these tokens are enabled in production.
  -------------------- ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------





### Interaction: HTTPS 

![HTTPS interaction screenshot](https://cloud.githubusercontent.com/assets/3138467/11080695/7cc7144a-87e4-11e5-840e-70b7a81b5a1e.png)



#### 38. Spoofing the Web Server Process  [State: Mitigation Implemented]  [Priority: High]  

  -------------------- -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
  **Category:**        Spoofing

  **Description:**     Web Server may be spoofed by an attacker and this may lead to unauthorized access to Browser Client. Consider using a standard authentication mechanism to identify the source process.

  **Justification:**   The webserver is authenticated by the HTTPs Certificate and our private key.
  -------------------- -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------





#### 39. Web Server Process Memory Tampered  [State: Not Applicable]  [Priority: High]  

  -------------------- ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
  **Category:**        Tampering

  **Description:**     If Web Server is given access to memory, such as shared memory or pointers, or is given the ability to control what Browser Client executes (for example, passing back a function pointer.), then Web Server can tamper with Browser Client. Consider if the function could work with less access to memory, such as passing data rather than pointers. Copy in data provided, and then validate it.

  **Justification:**   Web Server is on a private server and does not share memory.
  -------------------- ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------





#### 40. Potential Data Repudiation by Browser Client  [State: Mitigation Implemented]  [Priority: High]  

  -------------------- -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
  **Category:**        Repudiation

  **Description:**     Browser Client claims that it did not receive data from a source outside the trust boundary. Consider using logging or auditing to record the source, time, and summary of the received data.

  **Justification:**   IIS Access logs will configured to include this information.
  -------------------- -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------





#### 41. Potential Process Crash or Stop for Browser Client  [State: Mitigation Implemented]  [Priority: High]  

  -------------------- -----------------------------------------------------------------------------------------------------
  **Category:**        Denial Of Service

  **Description:**     Browser Client crashes, halts, stops or runs slowly; in all cases violating an availability metric.

  **Justification:**   We will do testing to ensure that our site does not cause browsers to become unstable.
  -------------------- -----------------------------------------------------------------------------------------------------





#### 42. Data Flow HTTPS Is Potentially Interrupted  [State: Mitigation Implemented]  [Priority: High]  

  -------------------- --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
  **Category:**        Denial Of Service

  **Description:**     An external agent interrupts data flowing across a trust boundary in either direction.

  **Justification:**   If an ISP, government or other entity disrupts traffic between our server and clients or stripe we would no longer be able to process sales. We would take all aproprate steps to ensure that this does not occur.
  -------------------- --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------





#### 43. Elevation Using Impersonation  [State: Not Applicable]  [Priority: High]  

  -------------------- ------------------------------------------------------------------------------------------------------------
  **Category:**        Elevation Of Privilege

  **Description:**     Browser Client may be able to impersonate the context of Web Server in order to gain additional privilege.

  **Justification:**   This does not apply in our case.
  -------------------- ------------------------------------------------------------------------------------------------------------





#### 44. Browser Client May be Subject to Elevation of Privilege Using Remote Code Execution  [State: Mitigation Implemented]  [Priority: High]  

  -------------------- --------------------------------------------------------------------------------------------------------------------------------------------------------------------------
  **Category:**        Elevation Of Privilege

  **Description:**     Web Server may be able to remotely execute code for Browser Client.

  **Justification:**   It certianly could (and does) execute javascript code on the client that support it. Existing XSS Mitigations will ensure that only authorized code is sent to browsers.
  -------------------- --------------------------------------------------------------------------------------------------------------------------------------------------------------------------





#### 45. Elevation by Changing the Execution Flow in Browser Client  [State: Mitigation Implemented]  [Priority: High]  

  -------------------- --------------------------------------------------------------------------------------------------------------------------------------------------------------------------
  **Category:**        Elevation Of Privilege

  **Description:**     An attacker may pass data into Browser Client in order to change the flow of program execution within Browser Client to the attacker's choosing.

  **Justification:**   It certianly could (and does) execute javascript code on the client that support it. Existing XSS Mitigations will ensure that only authorized code is sent to browsers.
  -------------------- --------------------------------------------------------------------------------------------------------------------------------------------------------------------------
