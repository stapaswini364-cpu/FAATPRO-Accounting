import { useState } from "react";


const ForgotPassword = () => {


  const [email,setEmail] = useState("");



  const handleSubmit = (e)=>{

    e.preventDefault();


    console.log(email);


  };



  return (

    <div className="min-h-screen flex items-center justify-center bg-gray-100">


      <div className="bg-white p-8 rounded-xl shadow-md w-full max-w-md">


        <h1 className="text-3xl font-bold text-center mb-6">

          Forgot Password

        </h1>



        <form onSubmit={handleSubmit}>


          <label className="block mb-2">

            Email

          </label>


          <input

            type="email"

            value={email}

            onChange={(e)=>setEmail(e.target.value)}

            placeholder="Enter your email"

            className="w-full border rounded-lg px-4 py-2 mb-5"

            required

          />



          <button

            type="submit"

            className="w-full bg-blue-600 text-white py-2 rounded-lg hover:bg-blue-700"

          >

            Send Reset Link

          </button>



        </form>


      </div>


    </div>

  );

};


export default ForgotPassword;