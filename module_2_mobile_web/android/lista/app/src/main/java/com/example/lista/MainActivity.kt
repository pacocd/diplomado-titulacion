package com.example.lista

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import androidx.recyclerview.widget.LinearLayoutManager
import kotlinx.android.synthetic.main.activity_main.*

class MainActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)
        setupCountriesRecyclerView()
    }

    private fun setupCountriesRecyclerView() {
        val adapter = CountryRowAdapter(Country.create()) { handleItemTapped(it) }
        countriesRecyclerView.adapter = adapter
        countriesRecyclerView.layoutManager = LinearLayoutManager(this)
        countriesRecyclerView.setHasFixedSize(true)
    }

    private fun handleItemTapped(country: Country) {
        populationTextView.text = "Población de ${country.name}: \n${country.population}"
    }
}