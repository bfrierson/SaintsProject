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

"Saints link dropdown, verfiy it contains 4 sites" &&& fun _ ->
    ()


    



run()
System.Console.ReadKey()
quit()