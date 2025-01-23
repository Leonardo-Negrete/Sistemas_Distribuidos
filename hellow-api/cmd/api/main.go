package main

import (
	"encoding/json"
	"fmt"
	"net/http"
)

type Response struct{
	Message string 
}


func main(){
	http.HandleFunc("/hello-world", handler)
	fmt.Println("Starting server on: 80")
	err := http.ListenAndServe(":80", nil)
	if err != nil{
		fmt.Println("Error starting server:", err)
	}
}

func handler(w http.ResponseWriter, r *http.Request){
	w.Header().Set("Content-Type", "application/json")
	response := Response{Message: "Hello Worl :D"}
	if err := json.NewEncoder(w).Encode(response); err != nil{
		http.Error(w, err.Error(), http.StatusInternalServerError)
	}
}

//var PublicVariable;
//var privateVariable;

/*func PublicMethod(){

}

func privateMethod(){

}*/