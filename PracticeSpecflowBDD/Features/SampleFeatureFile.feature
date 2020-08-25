Feature: SampleFeatureFile
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum & difference of two numbers

@SmokeTest
Scenario: Add two numbers
	Given the first number is 50
	And the second number is 70
	When the two numbers are added
	Then the result should be 120
	And this step should be pending for reports to be displayed

@SmokeTest
Scenario: Add two numbers again
	Given the first number is 50
	And the second number is 70
	When the two numbers are added
	Then the result should be 1200
	
@SmokeTest
Scenario: Sub two numbers
	Given the first number is 70
	And the second number is 50
	When the two numbers are Substracted
	Then the result should be 20



