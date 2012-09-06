@fixture
Feature: Homepage
	In order to see all information on homepage
	As a typical user
	I want to see latest posts with additional information

@transactional
Scenario: Enter homepage should see page
	When: user enters homepage
	Then: homepage should appear without errors

@transactional
Scenario: Enter homepage should see posts
	When user enters homepage
	Then title of five posts should be displayed
	