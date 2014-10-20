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
let navBar = ".nav.navbar-nav li a"


//Helpers
let yardage name = sprintf "//td[contains(text(), '%s')]/../td[3]" name

start chrome

"Find Drew Bree passing yards" &&& fun _ ->
    url "file:///C:/Projects/SaintsProject/index.html"
    click "Stats"
    "//td[contains(text(), 'Drew Brees')]/../td[3]" == "1574"

"Find the Alert on the row with Drew Brees" &&& fun _ ->
    click "//td[contains(text(), 'Drew Brees')]/..//a"
    alert() == "WHO DAT!"
    acceptAlert()

"Find DeMarco Murray rushing yards" &&& fun _ ->
    url "file:///C:/Projects/SaintsProject/index.html"
    click "Stats"
    "//td[contains(text(), 'DeMarco Murray')]/../td[3]" == "670"

"Find the Alert on the row with DeMarco Murray" &&& fun _ ->
    click "//td[contains(text(), 'DeMarco Murray')]/..//a"
    alert() == "How bout them Cowboys!"
    acceptAlert()

"Find Steve Smiths Rec Yards using function" &&& fun _ ->
    yardage "Steve Smith" == "463"

"Testing clicking on links by text, IDs, then verifing you are on correct page" &&& fun _ ->
    click "Schedule"
    on schedulePage

    click "Stats"
    on statsPage

    click home
    on homePage

"Check Panel is displayed, click toggle button, and verify it is now gone." &&& fun _ ->
    displayed panelGone
    click toggle
    notDisplayed panelGone

"Can enter text into search, and other inputs, verify" &&& fun _ ->
    searchBar << "Drew Brees"
    searchBar == "Drew Brees"

    inputSuccess << "Pierre Thomas"
    inputSuccess == "Pierre Thomas"

    inputWarning << "Junior Gallette"
    inputWarning == "Junior Gallette"

    inputError << "Cam Jordan"
    inputError == "Cam Jordan"

"Click the button to change the text , verify" &&& fun _ ->
    panelText == "Eric Martin"
    click changeText
    panelText == "Marques Colston"

//   DROPDOWN TEST
"Verify Saints player dropdown has certain options" &&& fun _ ->
    click "Fun Page"
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
    check "#db9"
    check "#coach"
    check "#refs"
    
    uncheck "#db9"
    uncheck "#coach"
    uncheck "#refs"

"Check NavBar for links" &&& fun _ ->
    navBar *= "Stats"
    navBar *= "Schedule"
    navBar *= "Hall of Fame"
    navBar *= "Fun Page"
    navBar *= "Saints Links"

    count navBar 9 

run()
System.Console.ReadKey()
quit()