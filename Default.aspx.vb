
Partial Class _Default
    Inherits System.Web.UI.Page
    Protected Sub PerformCalcButton_Click(sender As Object, e As System.EventArgs) Handles PerformCalcButton.Click
        'specify constant values
        Const Interest_Clacs_Per_Year As Integer = 12
        Const Payments_Per_Year As Integer = 12

        'create variables to hold the values entered by the user
        Dim P As Decimal = LoanAmount.Text
        Dim r As Decimal = Rate.Text / 100
        Dim t As Decimal = MortgageLength.Text

        Dim rateperperiod As Decimal
        rateperperiod = r / Interest_Clacs_Per_Year

        Dim payperiods As Integer
        payperiods = t * Payments_Per_Year

        Dim annualrate As Decimal
        annualrate = (Math.Exp(Interest_Clacs_Per_Year * Math.Log(annualrate + 1) / Math.Log(1 + rateperperiod)) - 1)

        Dim interperpayment As Decimal
        interperpayment = (Math.Exp(Math.Log(annualrate + 1) / payperiods) - 1) * payperiods

        'now compute the total cost of the loan\
        Dim intpermonth As Decimal = interperpayment / Payments_Per_Year

        Dim costpermonth = P * intpermonth / (1 - Math.Pow(intpermonth + 1, -payperiods))

        'display results in the results lavel web control
        Results.Text = "your mortgage payment per month is $" & costpermonth.ToString("#,####.##")




    End Sub
End Class
