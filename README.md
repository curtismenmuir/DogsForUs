# DogsForUs
DogsForUs - C# Web API for managing a list different types of dogs.

Live version - http://dogsforus20181028114855.azurewebsites.net

# Breif
"You are a freelance web developer. A client brings you a list of dogs (use the dogs.json file
associated with this test), and wants you to make the list viewable, and editable, via the internet."
- The dog list interface can be exposed however you like; GUI, raw data endpoints,
anything is fine, as long as it is served over HTTP in a browser.
- Any programming language, frameworks, methodologies, patterns, etc.
- The interface must allow a user to create, read, update, and delete dogs.
- Interactions with the list must persist, i.e. if I delete the Pug breed, close my browser,
then reopen my browser, and view the list, the Pug breed must not be present.
- 

# Description
Web Page:
On load, the web page will make a HTTP GET to the web service to reutrn the dog collection. This information will be used to populate the main accordion dislay in the homepage.
The user can exand all of the items, with the accodrion body containing a description about the dog, along with listing any Sub-Breeds. The user can also edit and delete the dog from the Edit and Delete buttons which are located in the Accordion body. If the user selects either option, they will be displayed with a modal popup allowing the user to confirm their changes.
There is an Add button situated above the accordion, clicking this will open the Add New Dog modal popup - where the user can enter the details for a new dog to be added to the list. 
All the inputs are validated to ensure that no user enters to with the same name (breed). 

Web Service:
1. GetAllDogs() - API Controller which returns the collection of dogs
- Usage: HTTP GET ../api/dogs
- EG GET http://dogsforus20181028114855.azurewebsites.net/api/dogs
- Returns: ActionResult - Ok(_dogColletion) or BadRequest()

2. AddDog() - API Controller which adds a new dog to the collection
- Usage: HTTP POST ../api/dogs - new dog details added in x-www-form-urlencoded 
- EG POST http://dogsforus20181028114855.azurewebsites.net/api/dogs (New dog details included in POST)
- Returns: ActionResult - Ok() or BadRequest()

3. EditDog() - API Controller which edits a dog in the collection
- Usage: HTTP PUT ../api/dogs/Original Dog Name - new dog details added in x-www-form-urlencoded 
- EG PUT http://dogsforus20181028114855.azurewebsites.net/api/dogs/Bulldog (New dog details included in PUT)
- Returns: ActionResult - Ok() or BadRequest()

4. DeleteDog() - API Controller which deletes a dog from the collection
- Usage: HTTP DELETE ../api/dogs/DogName EG
- EG GET http://dogsforus20181028114855.azurewebsites.net/api/dogs/Terrier
- Returns: ActionResult - Ok() or BadRequest()
