open canopy
open runner

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



run()
System.Console.ReadKey()
quit()