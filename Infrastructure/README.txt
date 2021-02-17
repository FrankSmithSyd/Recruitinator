********************************
**** Infrastructure project ****
********************************

- The Infrastructure project is responsible for mediating between our domain and data mapping layers.
- In concrete terms, it's where we are putting our middleware that implements a repository pattern.
- It also contains classes with dependencies on external resources. 
- As we are consuming the results of the JobAdder coding challenge API, this is where we shall do so.
- JobAdder API actions ( see  https://jobadder1.docs.apiary.io/#reference )
    - http://private-76432-jobadder1.apiary-mock.com/candidates
    - http://private-76432-jobadder1.apiary-mock.com/jobs