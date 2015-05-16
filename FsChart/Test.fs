module Test

#if INTERACTIVE
#I "../packages/FSharp.Charting.0.90.10/lib/net40"
#endif

open FSharp.Charting
open System
open NUnit.Framework
open FSharp.Charting.ChartTypes
open System.Drawing.Imaging
open System.Windows.Forms
open System.Linq

let Save filename (c:GenericChart) =
    use cc = new ChartControl(c)
    cc.Dock <- DockStyle.Fill
    use f = new Form()
    f.Size <- System.Drawing.Size(1500, 600)
    f.Controls.Add cc
    f.Load |> Event.add (fun _ -> c.SaveChartAs(filename, ChartImageFormat.Png); f.Close()) // yay
    Application.Run f

let countryData = 
    [ "Africa", 1033043; 
      "Asia", 4166741; 
      "Europe", 732759; 
      "South America", 588649; 
      "North America", 351659; 
      "Oceania", 35838  ]

[<Test>]
let ``ShouldCreateBarChart``() =
    let chart = Chart.Bar countryData
    chart |> Save "chart.bar.png"

[<Test>]
let ``ShouldCreateColumnChart``() =
   Chart.Column (countryData, Title="Hello Chart") |> Save "chart.column.png"

[<Test>]
let ``ShouldCreateMonthlyReport``() =
    let range = [for x in 1..12 -> DateTime(2015, x, 5).ToString("MMM") , x * 2]
    Chart.Column range |> Save "monthly.report.png"







