import React, { Component } from 'react';

export class SearchSiteOccurences extends Component {
  displayName = SearchSiteOccurences.name

  constructor(props) {
    super(props);
    this.state = { occurencesString: [], loading: true , inputKeywordsValue: ""};
    this.handleClick = this.handleClick.bind(this);
    this.updateinputKeywordsValue = this.updateinputKeywordsValue.bind(this);
    
    let url = 'api/Search/SearchSiteOccurences';
    let options = {
                method: 'POST',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json;charset=UTF-8'
                },
                body: JSON.stringify({
                    url: "https://www.google.com",
                    siteName: "sympli",
                    keywords: "e-settlment",
                })
            };
            
    fetch(url, options)
      .then(response => {
        if(response.ok) {return response.json()}
        else {alert("swr"); 
        
        const data = response.json();
        const error = (data && data.message) || response.status;
        return Promise.reject(error);}
      })
      .then(data => {
        this.setState({ occurencesString: data, loading: false, inputKeywordsValue:"" });
      })
      .catch((error) => {
        console.log(error)
      });
  }

  static renderSearchSiteOccurencesTable(occurencesString) {
    return (
      <table className='table'>
        <thead>
          <tr>
            <th>Occurences</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td>Enter Keyworks to search for</td>
            <td><input type="text" onChange={this.updateinputKeywordsValue}/></td>
          </tr>
          <tr>
            <td>Enter Engine Name</td>
            <td></td>
          </tr>
          <tr>
            <td>Enter Site Name</td>
            <td></td>
          </tr>
          <tr key="1">
              <td colSpan='2'>{occurencesString.occurencesResult}</td>
          </tr>
          <tr><td colSpan='2'>
            <input type="button" value="Search" id="searchBtn" onClick={this.handleClick}/></td></tr>
        </tbody>
      </table>
    );
  }

  updateinputKeywordsValue(evt) {
    this.setState({
      inputKeywordsValue: evt.target.value
    });
  }

  handleClick(){
    alert("value of input field : "+this.state.inputKeywordsValue);
    console.log("value of input field : "+this.state.inputKeywordsValue);
   }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : SearchSiteOccurences.renderSearchSiteOccurencesTable(this.state.occurencesString);

    return (
      <div>
        <h1>Search Site Occurences</h1>
        <p>This component demonstrates fetching data from the server.</p>
        {contents}
      </div>
    );
  }
}
