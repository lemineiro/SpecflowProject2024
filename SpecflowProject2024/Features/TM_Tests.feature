Feature: This test suite tests scenarios for the following

1.Create TM Record
2. Edit TM Record
3. Delete TM Record

Scenario: A. Verify user is able to create a new TM record
 Given user logs into turnup portal
 And user navigates to the TM page
 When user creates a new TM record
 Then system should save the new TM record

 Scenario: B. Verify user is able to edit an existing TM record
 Given user logs into turnup portal
 And user navigates to the TM page
 When user edits an existing TM record
 Then system should save the edited TM record

 Scenario: C. Verify user is able to delete an existing TM record
 Given user logs into turnup portal
 And user navigates to the TM page
 When user deletes an existing TM record
 Then system should delete the TM record
