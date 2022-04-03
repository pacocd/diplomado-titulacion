package com.example.second_activity

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.view.View
import android.widget.Toast
import kotlinx.android.synthetic.main.activity_main.*

class MainActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)
    }

    fun enter(view: View) {
        if (!isValidPassword()) return showErrorToast()

        val intent = Intent(this, AboutActivity::class.java)
        startActivity(intent)
    }

    private fun isValidPassword(): Boolean {
        return passwordEditText.text.toString() == "abc123"
    }

    private fun showErrorToast() {
        Toast
            .makeText(this, "Contraseña inválida", Toast.LENGTH_SHORT)
            .show()
    }
}