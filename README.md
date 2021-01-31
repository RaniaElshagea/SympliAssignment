# SympliAssignment by Rania Elshageaa
Best practices in place
Implemented clean architecture practice - DDD
SOLID principles
DI
Unit testing

For future development
Extensive Error handling, Proper Logging and more test coverage
Front end error handling is not complete

Performance, availbility and reliability: 
use google api search endpoints to avoid running into 429 issues (too many requests)
use google api search endpoints instead of scrapping by tag names that can change anytime
add more unit tests to google apis when in place.
Not to allow only string for URL, instead provide search engines options and empty string in case new engines are to implement.
be more robust about search engine names, exmple: gogle, www.google.com, htp://gogle.com , different combinations should all match to google at the end.
To extend Language options, number of results to scrap and probably dispaly returned URLs

UI could be deployed seperatly from back end for better performance and quicker CICD
Nugget packages can be inplace for different projects to avoid building or deploying all projects if not needed.


