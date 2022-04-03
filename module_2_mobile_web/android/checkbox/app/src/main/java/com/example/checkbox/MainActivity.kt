package com.example.checkbox

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.view.View
import android.widget.EditText
import kotlinx.android.synthetic.main.activity_main.*

class MainActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)
    }

    fun doOperation(view: View) {
        val firstValue = parsedDoubleFromView(firstValueInput)
        val secondValue = parsedDoubleFromView(secondValueInput)
        var result: String = ""
        if (additionCheckbox.isChecked) {
            result += additionResult(firstValue, secondValue)
        }
        if (subtractionCheckbox.isChecked) {
            result += subtractionString(firstValue, secondValue)
        }
        resultTextView.text = result
    }

    private fun additionResult(firstValue: Double, secondValue: Double): String {
        return "Suma: ${firstValue + secondValue}\n"
    }

    private fun subtractionString(firstValue: Double, secondValue: Double): String {
        return "Resta: ${firstValue - secondValue}"
    }

    private fun parsedDoubleFromView(view: EditText): Double {
        return view.text.toString().toDoubleOrNull() ?: 0.0
    }
}