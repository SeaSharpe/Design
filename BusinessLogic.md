1. [Visitor Signs Up for Account](#visitor-signs-up-for-account)
1. [Member Logs In](#member-logs-in)
1. [Member/Visitor Views Events](#membervisitor-views-events)
1. [Member/Visitor Views Game](#membervisitor-views-game)
1. [Member Profile](#member-profile)
1. [Member Purchase Games](#member-purchase-games)
1. [Member Registers for Event](#member-registers-for-event)
1. [Member Rates/Reviews a Game](#member-ratesreviews-a-game)
1. [Member Adds Game to Wishlist](#member-adds-game-to-wishlist)
1. [Member Adds Another User to Their Friends and Family List](#member-adds-another-user-to-their-friends-and-family-list)
1. [Member Views Another Member’s Wish List](#member-views-another-members-wish-list)
1. [Employee Logs In](#employee-logs-in)
1. [Employee Adds Event](#employee-adds-event)
1. [Employee Edits Event](#employee-edits-event)
1. [Employee Deletes Event](#employee-deletes-event)
1. [Employee Adds Game](#employee-adds-game)
1. [Employee Edits Game](#employee-edits-game)
1. [Employee Deletes Game](#employee-deletes-game)
1. [Employee Ships Games/Marks Order as Processed](#employee-ships-gamesmarks-order-as-processed)
1. [Employee Approves Reviews](#employee-approves-reviews)
1. [Employee Views Reports](#employee-views-reports)

# Visitor Signs Up for Account
- Visitor must not have an account registered for that E-mail address
- Sign up fields must not be empty
- Sign up fields must follow data validation rules
- Signs up for account
- Commit to database

# Member Logs In
- User must have an account created
- Email and password fields much not be empty
- Password entered must match stored password for specified user
- User logs in to site

# Member/Visitor Views Events
- Login is not required
- User selects Events link
- View list of events
- Select event name to view specific event

# Member/Visitor Views Game Details
- Login is not required
- User selects Shop link
- Search for games
- Select the game name to display game details
- View reviews/ratings

# Member Profile
- Must be logged in as Member
- Set up profile information
- Opt in / opt out of promotional E-mails
- Set platform preference
- Set game category preference
- Enter/Edit “ship to” address
- Delete “ship to” address
- Edit address
- User information and address fields must not be empty
- User information and address fields must follow validation rules
- Reset password
- Commit to database

# Member Purchase Games
- Must be logged in as Member
- Member must have game selected
- Add game to cart
- View cart
- Checkout
- Download games/or select games to be shipped
- Commit to database

# Member Registers for Event
- Must be logged in as Member
- Member must be viewing event
- Member registers for event 
- Commit to database

# Member Rates/Reviews a Game
- Must be logged in as Member
- Must be on a game’s details page
- Review games - must be approved be employee before commited
- Rate games - Commit to database

# Member Adds Game to Wishlist
- Must be logged in as Member
- Must be on a game’s details page
- Adds game to wish list
- Commit to database

# Member Adds Another User to Their Friends and Family List
- Must be logged in as Member
- Other user must have an account created
- Search by name
- Add user to Friends and Family List
- Commit to database

# Member Views Another Member’s Wish List
- Must be logged in as Member
- Other Member must be on Friends and Family List
- View other Member’s wish list

# Employee Logs In
- User must have an Employee account
- Email and password fields must not be empty
- Entered password must match stored password for specified user
- User logs in to site as Employee

# Employee Adds Event
- Must be logged in as Employee
- Event must not already exist
- Event fields must not be empty
- Event fields must match validation rules
- Employee adds event
- Commit to database

# Employee Edits Event
- Must be logged in as Employee
- Must be on an event’s page
- Event fields must not be empty
- Event fields must match validation rules
- Employee edits event
- Commit to database

# Employee Deletes Event
- Must be logged in as Employee
- Must be on an event’s page
- Employee deletes event
- Removed from database

# Employee Adds Game
- Must be logged in as Employee
- Game must not already exist
- Game fields must not be empty
- Game fields must match validation rules
- Employee adds game
- Commit to database

# Employee Edits Game
- Must be logged in as Employee
- Must be on the game’s editable page
- Game fields must not be empty
- Game fields must match validation rules
- Employee edits game
- Commit to database

# Employee Deletes Game
- Must be logged in as Employee
- Must be on the game’s editable page
- Employee deletes game
- Game removed from database

# Employee Ships Games/Marks Order as Processed
- Must be logged in as Employee
- Employee must be on orders page
- Employee selects an order 
- Employee packages the items on the order
- Employee marks order as processed
- Commit to database

# Employee Approves Reviews
- Must be logged in as Employee
- Employee must be on reviews page
- Employee selects review to review
- Employee reviews review
- Employee approves review
- Commit to database

# Employee Views Reports
- Must be logged in as Employee
- Employee selects report to view
- Employee views report
- Employee may print report
