package com.example.radiobuttons

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.view.View
import android.widget.RadioButton
import kotlinx.android.synthetic.main.activity_main.*

class MainActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)
    }

    fun doOperation(view: View) {
        val firstValue: Double = firstValueInput.text.toString().toDoubleOrNull() ?: 0.0
        val secondValue: Double = secondValueInput.text.toString().toDoubleOrNull() ?: 0.0

        resultTextView.text = "Resultado ${getResult(firstValue, secondValue)}"
    }

    private fun getResult(firstValue: Double, secondValue: Double): Double {
        val selectedRadioButton = findViewById<RadioButton>(radioGroup.checkedRadioButtonId)
        if (selectedRadioButton.text == "Suma") {
            return firstValue + secondValue
        }
        return firstValue - secondValue
    }
}