package com.example.suma

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.view.View
import kotlinx.android.synthetic.main.activity_main.*

class MainActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)
    }

    fun addition(view: View) {
        val firstValue: Double = firstNumberInput.text.toString().toDoubleOrNull() ?: 0.0
        val secondValue: Double = secondNumberInput.text.toString().toDoubleOrNull() ?: 0.0
        val result: Double = firstValue + secondValue

        resultTextView.text = "El resultado es ${result}"
    }
}