import React, {useState} from 'react'
import FacebookLogin from 'react-facebook-login';

export default function Facebook() {
    const [fb, setFb] = useState({
        name:'',
        email : '',
        picture :'',
        accessToken:'',
        isLoggedIn : false
    });

    const componentClicked = () => {
        console.log("componentClicked");
    }
      
    
    const responseFacebook = (response) => {
        console.log(response)
       setFb({
        name: response.name,
        email: response.email,
        accessToken:response.accessToken,
        picture: response.picture.data.url,
        isLoggedIn: true
       })
    }
      

  return (
    <div>
        <h3>Facebook Login</h3>
        {fb.isLoggedIn? 
            (
                <>
                    <h1> {fb.name} </h1> 
                    <img width={50} height={50} src={fb.picture} />
                    <h3> {fb.email} </h3>
                    <p> {fb.accessToken} </p>
                </>
                )
            :
            (   <>
                    { <FacebookLogin
                        appId="1002572553782056"
                       // autoLoad={true}
                        fields="name,email,picture"
                        onClick={componentClicked}
                        callback={responseFacebook} /> }
                </>
             )   
              
        }

      

    </div>
  )
}

