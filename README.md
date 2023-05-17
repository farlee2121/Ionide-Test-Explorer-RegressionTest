

# Test Cases

Test Tree Structure
- Expecto test lists create a hierarchy of test groups
- Nested classes show as a hierarch of test groups
  - i.e. we support both `.` and `+` separators in test fully qualified names
- Both static and instance-based classes work for frameworks that support both (NUnit, XUnit)
- Tests from C# projects are shown with the same expected behaviors, but no locations
- Tests written with libraries we don't support code analysis for are displayed (i.e. MSTest)
- Tests created indirectly display correctly (i.e. wrapping an expecto function)

Build and project behaviors
- Tests can be discovered with or without a solution file
- Tests should be discovered from any project that has them
- Tests should be discovered even if the project has never been built or tests ran

Tests Statuses
- All test result statuses should display
  - success
  - error (and shows error)
  - skipped
- Should show yellow while building
- should show spinner while executing
- Projects that fail to build show error (not failure)
- I should be able to run any selection of tests and groups and only those tests display status updates


Update behaviors
- If we have code location
  - Renaming a test in code renames it in the explorer
  - removing the test from code removes it from the explorer
  - adding a test in code adds it to the explorer in the right group
  - Code-updated tests can be run as expected
- Code locations should be preserved when refreshing the test list
- Running a group will update child tests to reflect the current state in code (i.e. children added, removed, or renamed)
- Warn the user if no tests are executed (i.e. the test no longer exists. Especially pertinent for tests without a code location) 
- Refreshing the test list discovers added test projects
- Run a subset of tests, exit and reopen vscode. All expected tests should still be discovered. (Ensure that we don't load from incomplete test result files)

Location-based features
- Expecto locations are mapped
- Nunit locations are mapped
- Xunit locations are mapped
- Tests with locations can
  - display errors inline after a test run
  - display gutter test actions (run, test status, etc)
  - go to test / reveal in test explorer


Test Results View
- If I open the test console output. I see all errors failure and warnings, including tests without code locations
- If I click on the test run. Errors, failures, and warnings should be shown, including tests without code locations
- In the Test Results tree, errored tests (i.e. project doesn't compile) should show their error message
- In the Test Results trees, failed tests should show their failure messages
  - Failed tests without code locations should still display here


Simulate bottlenecks
- large projects
- slow tests
  - Smaller test selections shouldn't be impacted
  - (Unfortunately, there doesn't seem to be a way around this impacting test discovery)
- complex build dependencies
