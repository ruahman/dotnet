
# first create a solution
`dotnet new sln --name <name-of-solution-file>`
or 
`dotnet new sln -o <name-of-solution-folder>`

# create a project 
`dotnet new console -o <name-of-project>`

# create a test project 
`dotnet new xunit -o <name-of-test-project>`

# add projects to solution 
`dotnet sln add <path/to/project>`

# add reference to project from test project 
`dotnet add reference ../<project-you-want-to-test>`

# run tests 
`dotnet test`
or 
`dotnet test --no-restore -v m --filter="FullyQualifiedName=<namespace>.<class>.<method>"`
- no-restore : makes it go faster without cheacking if the project needs to be restored 
- v m : sets verbosity level to minimum 
- filter : you can filter out which test you want to run.  check help guides
