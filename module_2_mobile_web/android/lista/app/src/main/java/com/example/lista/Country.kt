package com.example.lista

interface ArrayFactory<T> {
    fun create(): Array<T>
}

data class Country(val name: String, val population: Int) {
    companion object: ArrayFactory<Country> {
        override fun create(): Array<Country> {
            return arrayOf(
                Country("Argentina", 40000000),
                Country("Chile", 17_000_000),
                Country("Paraguay", 6_500_000),
                Country("Bolivia", 10_000_000),
                Country("Perú", 30_000_000),
                Country("Ecuador", 14_000_000),
                Country("Brasil", 183_000_000),
                Country("Colombia", 44_000_000),
                Country("Venezuela", 31_000_000),
                Country("Uruguay", 3_500_000),
            )
        }
    }
}
