'use client'

const Home = async () => { 
    const response = await fetch('https://hakimhub-api-dev-wtupbmwpnq-uc.a.run.app/api/v1/search?institutions=false&from=1&size=8', {
    method: 'POST',
});

    const data = await response.json();
    // console.log(data)
  return (
    <>
    hello
    {data.data[0].mainInstitution.institutionName}
    </>
  )
  
  }
  export default Home