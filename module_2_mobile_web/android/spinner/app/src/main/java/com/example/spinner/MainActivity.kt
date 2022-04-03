package com.example.spinner

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.view.View
import android.widget.ArrayAdapter
import android.widget.EditText
import kotlinx.android.synthetic.main.activity_main.*

class MainActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)
        setupSpinner()
    }


    private fun setupSpinner() {
        val options: Array<String> = arrayOf("Suma", "Resta", "Multiplicación", "División")
        ArrayAdapter(this, android.R.layout.simple_spinner_item, options)
            .also {
                it.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item)
                operationsSpinner.adapter = it
            }
    }

    fun doOperation(view: View) {
        if (operationsSpinner.selectedItem.toString().isBlank()) return
        val firstValue: Double = parsedDoubleForView(firstValueInput)
        val secondValue: Double = parsedDoubleForView(secondValueInput)
        resultTextView.text = when (operationsSpinner.selectedItem.toString()) {
            "Suma" -> firstValue + secondValue
            "Resta" -> firstValue - secondValue
            "Multiplicación" -> firstValue * secondValue
            "División" -> firstValue / secondValue
            else -> 0
        }.toString()
    }

    private fun parsedDoubleForView(view: EditText): Double {
        return view.text.toString().toDoubleOrNull() ?: 0.0
    }
}