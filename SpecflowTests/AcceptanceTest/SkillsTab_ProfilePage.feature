Feature: SkillsTab_ProfilePage
	In order to update my profile 
	As a skill trader
	I want to add the Skills that I know
@mytag
Scenario: Check if user could able to add a skill
	Given I clicked on the Skills tab under Profile page
	When I add a new Skill
	Then that skill should be displayed on my listings

Scenario: Check if the user gets a message to enter all details if missed Skill level adding a Skill
		Given I clicked on the Skills tab under Profile page
		When I add a new Skill by missing the Skill level
		Then there should be a pop up "Please enter Skill and experience level"
	

Scenario: Check if the user gets a message to enter all details if missed skill while adding a skill
		Given I clicked on the skills tab under Profile page
		When I add a new skill by missing the skill and entering skill level alone
		Then there should be a pop up "Please enter Skill and experience level"

Scenario: Check if the user could able to edit a Skill
		Given I clicked on the Skill tab under Profile page
		When I add a new Skill
		And Try to Edit the Skill and update
		Then that new skill should be displayed on my listings

Scenario: Check if the user could able to cancel an editing a Skill
		Given I clicked on the Skill tab under Profile page
		When I add a new Skill
		And I try to click on Edit and click on cancel button
		Then that same skill should be displayed on my listings


Scenario: Check if the user could able to get a message when trying to update a skill without modifing any input
		Given I clicked on the skill tab under Profile page
		When I add a new skill
		And click on Edit but do not to Edit anything and click on update
		Then I should able to get an error message "This skill is already added to your skill list" 

Scenario: Check if the user could able to delete a Skill
		Given I clicked on the Skill tab under Profile page
		When I add a new Skill
		And Try to Delete the Skill
		Then that Skill should not be displayed on my listings

Scenario: Check if the user could able to cancel adding a Skill
		Given I clicked on the Skill tab under Profile page
		When I cancel adding a new Skill
		Then that Skill should not be displayed on my listings

Scenario: Check if the user is able to enter same Skill and same level
		Given I clicked on the Skill tab under Profile page
		When I add a new Skill
		And I add the same Skill and same level
		Then I should able to get an error message "This Skill is already exist in your Skill list" 

Scenario: Check if the user is able to enter same Skill and differnt level
		Given I clicked on the Skill tab under Profile page
		When I add a new Skill
		And I add the same Skill and different level
		Then I should able to get an error message "Duplicate Data"