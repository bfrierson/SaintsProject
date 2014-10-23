open canopy
open runner


//Selectors
let homePage = "file:///C:/Projects/SaintsProject/index.html"
let statsPage = "file:///C:/Projects/SaintsProject/stats.html"
let schedulePage = "file:///C:/Projects/SaintsProject/schedule.html"
let home = "#home"
let toggle = "#btn1"
let changeText = "#btn3"
let panelGone = "#pnl1"
let panelText = "#pnl3 .panel-body"
let searchBar = "#searchBar"
let inputSuccess = "#inputSuccess2"
let inputWarning = "#inputWarning2"
let inputError = "#inputError2"
let saintsList = "#saints option"
let saintsDropdown = "#saints"
let radioDrew = "#radio1"
let radioDuece = "#radio2"
let radioRicky = "#radio3"
let radioArchie = "#radio4"
let modalName = "#contact-name"
let modalEmail = "#contact-email"
let modalText = "#contact-text"
let coach = "#coach"
let navBar = ".nav.navbar-nav li a"


//Helpers
let yardage name = sprintf "//td[contains(text(), '%s')]/../td[3]" name
let findAlert name = sprintf "//td[contains(text(), '%s')]/..//a" name

start chrome

//Finding data using an xpath
"Find Drew Bree passing yards" &&& fun _ ->
    url "file:///C:/Projects/SaintsProject/index.html"              
    click "Stats"
    "//td[contains(text(), 'Drew Brees')]/../td[3]" == "1574"

"Find DeMarco Murray rushing yards" &&& fun _ ->
    url "file:///C:/Projects/SaintsProject/index.html"
    click "Stats"
    "//td[contains(text(), 'DeMarco Murray')]/../td[3]" == "670"

//Turning that nasty xpath into a method, much delicious!
"Find Steve Smiths Rec Yards using function" &&& fun _ ->
    yardage "Steve Smith" == "463"

//Finding the alert
"Find the Alert on the row with Drew Brees" &&& fun _ ->
    click "//td[contains(text(), 'Drew Brees')]/..//a"
    alert() == "WHO DAT!"
    acceptAlert()

"Find the Alert on the row with DeMarco Murray" &&& fun _ ->
    click "//td[contains(text(), 'DeMarco Murray')]/..//a"
    alert() == "How bout them Cowboys!"
    acceptAlert()

//Same Deal lets make this easier
"Make helper to make it easier" &&& fun _ ->
    click <| findAlert "Matt Ryan"
    alert() == "RISE UP!"
    acceptAlert()

//Testing if you are on the correct URL
"Testing clicking on links by text, IDs, then verifing you are on correct page" &&& fun _ ->
    click "Schedule"
    on schedulePage

    click "Stats"
    on statsPage

    click home
    on homePage

//Click some buttons
"Check Panel is displayed, click toggle button, and verify it is now gone." &&& fun _ ->
    displayed panelGone
    click toggle
    notDisplayed panelGone

"Click the button to change the text , verify" &&& fun _ ->
    panelText == "Eric Martin"
    click changeText
    panelText == "Marques Colston"

//Enter some text, verify its there
"Can enter text into search, and other inputs, verify" &&& fun _ ->
    searchBar << "Drew Brees"
    searchBar == "Drew Brees"

    inputSuccess << "Pierre Thomas"
    inputSuccess == "Pierre Thomas"

    inputWarning << "Junior Gallette"
    inputWarning == "Junior Gallette"

    inputError << "Cam Jordan"
    inputError == "Cam Jordan"

//     DROPDOWN TEST
"Verify Saints player dropdown has certain options" &&& fun _ ->
    click "Fun Page"
    saintsList *= "Select"
    saintsList *= "Drew Brees"
    saintsList *= "Mark Ingram"
    saintsList *= "Pierre Thomas"
    saintsList *= "Khiry Robinson"
    saintsList *= "Marques Colston"

    count saintsList 6

"If you set drop to a name does it stay?" &&& fun _ ->
    saintsDropdown << "Drew Brees"
    saintsDropdown == "Drew Brees"
    
    saintsDropdown << "Mark Ingram"
    saintsDropdown == "Mark Ingram"
    
    saintsDropdown << "Pierre Thomas"
    saintsDropdown == "Pierre Thomas"
   
    saintsDropdown << "Khiry Robinson"
    saintsDropdown == "Khiry Robinson"
   
    saintsDropdown << "Marques Colston"
    saintsDropdown == "Marques Colston"

//    Radio Buttons
"Can I select the radios buttons, verfiy they are selected and others are not" &&& fun _ ->
    click radioDrew
    selected radioDrew
    deselected radioDuece

    click radioDuece
    selected radioDuece
    deselected radioRicky

    click radioRicky
    selected radioRicky
    deselected radioArchie

    click radioArchie
    selected radioArchie
    deselected radioDrew

// Modals
"click modal, verify it pops up" &&& fun _ ->
    click "Suggestions"
    displayed "PWNED"
    click "Close"

"Click contact modal, enter information, verify info" &&& fun _ ->
    click "Contact Me"
    modalName << "Hans Gruber"
    modalEmail << "edge120x@yahoo.com"
    modalText << "This is random text for a modal."
    
    modalName == "Hans Gruber"
    modalEmail == "edge120x@yahoo.com"
    modalText == "This is random text for a modal."
    click "Submit"

//Checkboxes
"Check the check boxes" &&& fun _ ->
    check "#db9"                                //Check the check box using CSS to find the it
    selected "#db9"

    check coach                                 //Check the check box using a value to find the it
    selected coach

    click "The Refs"                            //Click the check box using Text to find the it ***Changed check to click as your click the text
    selected "#refs"                            //Have to use ID when verifing it was checked
    
    uncheck "#db9"                              //Uncheck the check box using CSS to find the it
    deselected "#db9"
    
    uncheck coach                               //Uncheck the check box using a varible to find the it
    deselected coach

    click "The Refs"                            //Click the check box using Text to find the it ***Changed uncheck to click as your click the text
    deselected "#refs"                          //Have to use ID when verifing it was unchecked

"Check NavBar for links, do a count on total links" &&& fun _ ->
    navBar *= "Stats"
    navBar *= "Schedule"
    navBar *= "Hall of Fame"
    navBar *= "Fun Page"
    navBar *= "Saints Links"
    navBar *= "New Orleans Saints Home Page"

    count navBar 9 

run()
System.Console.ReadKey()
quit()