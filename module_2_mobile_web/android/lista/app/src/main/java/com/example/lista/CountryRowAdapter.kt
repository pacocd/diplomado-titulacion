package com.example.lista

import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.TextView
import androidx.recyclerview.widget.RecyclerView
import kotlinx.android.synthetic.main.country_row_item.view.*

class CountryRowAdapter(private val countries: Array<Country>, private val itemTappedListener: (country: Country) -> Unit):
    RecyclerView.Adapter<CountryRowAdapter.CountryViewHolder>() {
    class CountryViewHolder(private val view: View, private val itemTappedListener: (Country) -> Unit):
        RecyclerView.ViewHolder(view) {
        private val countryTextView: TextView = view.countryTextView

        fun bind(country: Country) {
            countryTextView.text = country.name
            view.setOnClickListener { showCountryPopulation(country) }
        }

        private fun showCountryPopulation(country: Country) {
            itemTappedListener(country)
        }
    }

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): CountryViewHolder {
        val view = LayoutInflater
            .from(parent.context)
            .inflate(R.layout.country_row_item, parent, false)

        return CountryViewHolder(view, itemTappedListener)
    }

    override fun onBindViewHolder(viewHolder: CountryViewHolder, position: Int) {
        viewHolder.bind(countries[position])
    }

    override fun getItemCount() = countries.size
}