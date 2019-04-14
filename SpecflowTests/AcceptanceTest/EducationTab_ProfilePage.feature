Feature: EducationTab_ProfilePage
	In order to update my profile 
	As a skill trader
	I want to add the Education Details

Scenario: Check if user could able to add an Education 
	Given I clicked on the Education tab under Profile page
	When I add a new Education
	Then that Education should be displayed on my listings

Scenario: Check if the user gets a message to enter all details if missed any field while adding an education
		Given I clicked on the Education tab under Profile page
		When I add a new Education by missing one field
		Then there should be a pop up "Please enter all details"

Scenario: Check if the user could able to edit an Education 
		Given I clicked on the Education tab under Profile page
		When I add a new Education
		And Try to Edit the Education and update
		Then that new Education should be displayed on my listings

Scenario: Check if the user could able to cancel editing an Education
		Given I clicked on the Education tab under Profile page
		When I add a new Education
		And I try to click on Edit and click on cancel button
		Then that same Education details should be displayed on my listings


Scenario: Check if the user could able to get a message when trying to update an Education without modifing any input
		Given I clicked on the Education tab under Profile page
		When I add a new Education
		And Try not to Edit anything and click on update
		Then I should able to get an error message "This Information is already exist" 

Scenario: Check if the user could able to delete a Education
		Given I clicked on the Education tab under Profile page
		When I add a new Education
		And Try to Delete the Education
		Then that Education should not be displayed on my listings

Scenario: Check if the user could able to cancel adding a Education
		Given I clicked on the Education tab under Profile page
		When I cancel adding a new Education
		Then that Education should not be displayed on my listings

Scenario: Check if the user is able to get a pop up if entered same education details which already exist
		Given I clicked on the Education tab under Profile page
		When I add a new Education
		And I add the same Education details again
		Then I should able to get an error message "This Information is already exist" 
