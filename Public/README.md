# CSharp-WebAPI
this is a C#/.NET server with all crud operations for a single collection and an Angular 7 front end that will allow you to use the use the C# server.

## Usage Information
In Order to use the application, please open the entire project in visual studio community and press the run button. Next, you will need to have mongoDB installed on your computer and running globally. In addition, you will need to open up a terminal window and navigate to the public folder inside of the project. You will need to have the Angular CLI installed in order to follow the next step. Run `ng serve --open`. This will open up a browser window which will allow you to run a test of the Angular Application as well as the C# server.

## API Usage
You will also notice that there is another browser window that should have opened up to localhost:5000. Here is a list of endpoints that you should be able to use with that url.

url | method | body
------------------|----|----
http://localhost:5000/api/companies | GET | none
http://localhost:5000/api/companies/{id} | GET | none
http://localhost:5000/api/companies | POST | CompanyModel
http://localhost:5000/api/companies/{id} | PUT | CompanyModel
http://localhost:5000/api/companies/{id} | DELETE | None

## Comments
Thanks for looking into this small test project!

