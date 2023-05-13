

# Test Cases


## Test statuses

- All test resultstatuses should display
  - success
  - error (and shows error)
  - skipped
- Should show yellow while building
- should show spinner while executing



- Multiple test projects, shows tests from all projects
- Working without a solution file, still discovers tests
- test projects not in solution file
- Tests by unsupported test libraries (i.e. xunit) should show
- Tests by supported libraries (expecto, nunit) should support all location-based features
- Tests in C# project should show, but probably won't support location-based features
- Run partial
  - make sure other tests don't disappear
- Start from clean project / tests never run
  - should still discover tests
  - test what happens if only some test projects have been run
- Trying to set location after tree creation (after langauge server catches up)
- NUnit
- Test list always updates / reflects newest test structure after test run
  - may need to edit the Trx in a different editor, or just delete some items from the trx and make sure they show up again
  - also make sure removed tests disappear
- Can add a test project and the tests show up
- Wrapped test methods i.e. `testProperty'` where I set standard config for testPropertyWithConfig and assign it to a shorter name
