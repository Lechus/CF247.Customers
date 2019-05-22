#Customers WebAPI

Provides an interface to the CF247's customer data store.

## Overview

A simple Web Api that provides a ReST based interface into the CF247 customer data store. It is coded in C# and built using .NET Core 2.1.
There is a simple SQLExpress database that provides the physical storage.
There are built in integration tests that utilise Entity Framework's and .NET Core 2.1 capability to more easily execute integration tests
Swagger documentation is also available at http://localhost:49913/swagger

## Endpoints

### GET /api/customers

Returns all customer data

#### Request
Body : None
Parameters : None

#### Response
Example
[
  {
    "customerId": "string",
    "firstName": "string",
    "lastName": "string",
    "emailAddress": "string",
    "password": "string"
  }
]

### GET api/customers/{customerid}

Gets the customer details of a specific customer give their id (Guid)

#### Request
Parameters : customerID string (Guid)

#### Response
Example
{
  "customerId": "string",
  "firstName": "string",
  "lastName": "string",
  "emailAddress": "string",
  "password": "string"
}

### POST api/customers

Creates a new customer in the data store

#### Request
Parameters : none
Body: 
{
  "firstName": "string",
  "lastName": "string",
  "emailAddress": "string",
  "password": "string"
}

### PUT api/customers

Parameters : none
Body:
{
  "firstName": "string",
  "lastName": "string",
  "emailAddress": "string",
  "password": "string"
}

## Get started

1. Publish the SQL Server data base to a running SQL Server database
2. Configure the application.json setting file to use the correct settings

## Next Versions

1. Addition of Docker support
2. Authentication of user requests using JWT
3. Database to encrypt data to ensure data at rest is secure
4. Auditing capability to track data usage
5. PATCH method offerd as an alternative to PUT
