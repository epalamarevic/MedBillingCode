# Medical Billing Code

This repository is an ASP.Net MVC Web Application of a medical billing resource.
It provides ICD-10 billable codes for a common list of diagnosis and procedures. 
#### Mission:
To provide public users the ability to find diagnostic codes(ICD-10) to determin pricing of diagnoses and procedures.
We want you to be ready before you get that bill from your provider.

### What is an ICD-10 Code?
According to the World Health Organization, International Classificationof Diseases (ICD) “is the foundation forthe identification
of health trends and statistics globally, and the international standard for reporting diseases and health conditions.”
In betterterms, it is a healthcare medical code that is used to identify different types of illnesses, diseases, signs and symptoms.
The number 10 means that it is the 10th revision of the International Classification of Diseases.*

# Installation
- Clone/Pull down the repo in the directory of your choice. 
- Run the program by opening up the solution in Visual Studio.

# How to Use the Project
Once you run the project in Visual Studio, you should have a web page opened.
Navigate through the webpage, try a search, and click on tabs and any buttons you see. 
This should get you familiar with the front-end of theMVC.

#### Create/Update/Edit/Delete
In order to create, update, edit or delete a diagnosis, procedure or code you have to be an Admin.
##### How to become an Admin?
First create an Admin Role. In the footer section there is an Admin column, continue by clicking on the Role option and it directs you tothe page to create a role.
Once you created an Admin user role. Register and login (both are located under the Admin column).

To implement any of the back end CRUD for the data entries; make sure that the site you are on looks something like this:

://localhost:00000/ (Diagnosis,Procedure,DiagnosisCode,ProcedureCode)/ (Create,Edit,Delete)/ {id}

Follow the above website example and navigate through the create,edit and delete site to see how to implement them.
To edit or delete make sure you have the {id} parameter implemented, check to confirm your create, edit and delete
by looking at the list of diagnosis, procedures or codes.


# Contribution
Javascript, Jquery and C# were used in contribution to the application. Front-end of the application includes multiple javascript for the design of theweb page.
Sources were used in contribution to define correct ICD-10codes in relation to diagnosis and procedure.
Note that pricing included is not to be used as correct billableestimated price for the code.
#### Sources
- *ICD, World Health Organization:  https://www.who.int/classifications/icd/en/
- CloudCare: https://www.carecloud.com/
- Find-A-Code: https://www.findacode.com/index.html

# Credits
-Emina Palamarevic

# License
This project is in correspondence with MIT License.Copyright(c)
.NET Foundation and Contributors
All rights reserved.
Permissionis hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal 
in the Software without restriction, including without limitation the rights to 
use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, 
and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The abovecopyright notice and this permission notice shall be included in all copies orsubstantial portions of the Software.

THE SOFTWAREIS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS ORIMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
OF MERCHANTABILITY,FITNESS FOR A PARTICULAR PURPOSE AND NON INFRINGEMENT. IN NO EVENT SHALL THEAUTHORS OR COPYRIGHT HOLDERS 
BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF 
OR INCONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
