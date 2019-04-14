Feature: SpecFlowFeature1
	In order to update my profile 
	As a skill trader
	I want to add the languages that I know

@mytag
Scenario: TC01 Check if user could able to add a language 
	Given I clicked on the Language tab under Profile page
	When I add a new language
	Then that language should be displayed on my listings

Scenario: TC02 Check if the user could able to cancel adding a language
		Given I clicked on the Language tab under Profile page
		When I cancel adding a new language
		Then that language should not be displayed on my listings

Scenario: TC03 Check if the user is able to enter same language and same level
		Given I clicked on the Language tab under Profile page
		When I add a new language
		And I add the same language and same level
		Then I should able to get an error message "This language is already exist in your language list" 

Scenario: TC04 Check if the user is able to enter same language and differnt level
		Given I clicked on the Language tab under Profile page
		When I add a new language
		And I add the same language and different level
		Then I should able to get an information message "Duplicate Data"

Scenario: TC05 Check if user could able to add  maximum of 4 languages only
	Given I clicked on the Language tab under Profile page
	When I add 4 new Languages
	| Language | Level |
	| English  | Basic |
	| Telugu   | Basic |
	| Hindi    | Basic |
	| French   | Basic |
	Then the add New button should be invisible
	
Scenario Outline: TC06 Check if the user gets a message to enter all details if missed Field while adding a language
		Given I clicked on the Language tab under Profile page
		When I add a new language by not entering one of the fields <Language> and <Level>
		Then there should be a pop up Please enter language and level
Examples: 
		| Language | Level |
		| English  |       |
		|          | Basic |

Scenario: TC07 Check if the user could able to edit a language
		Given I clicked on the Language tab under Profile page
		When I add a new language
		And Try to Edit the Language and update
		Then that new language should be displayed on my listings

Scenario: TC08 Check if the user could able to cancel an editing a language
		Given I clicked on the Language tab under Profile page
		When I add a new language
		And I try to click on Edit and click on cancel button
		Then that same language should be displayed on my listings

Scenario: TC09 Check if the user could able to get a message when trying to update a language without modifing any input
		Given I clicked on the Language tab under Profile page
		When I add a new language
		And Try not to Edit anything and click on update
		Then I should able to get an error message that "This language is already added to your language list." 

Scenario: TC10 Check if the user could able to delete a language
		Given I clicked on the Language tab under Profile page
		When I add a new language
		And Try to Delete the Language
		Then that language should not be displayed on my listings














