import React, { Component } from 'react';

export class SearchSiteOccurences extends Component {
  displayName = SearchSiteOccurences.name

  constructor(props) {
    super(props);
    this.state = { occurencesString: [], loading: false , validationMsgs: false, inputKeywordsValue:"", inputEngineUrlValue:"", inputSiteNameValue:""};
    this.handleClick = this.handleClick.bind(this);
    this.updateInputKeywordsValue = this.updateInputKeywordsValue.bind(this);
    this.updateEngineUrlValue = this.updateEngineUrlValue.bind(this);
    this.updateSiteNameValue = this.updateSiteNameValue.bind(this);
  }

  static renderValidationMsgsTable(validationMsgs) {
    return (<div>{validationMsgs.validationMessages}</div>);
  };

  updateInputKeywordsValue(evt) {
    this.setState({
      inputKeywordsValue: evt.target.value
    });
  }

  updateEngineUrlValue(evt) {
    this.setState({
      inputEngineUrlValue: evt.target.value
    });
  }

  updateSiteNameValue(evt) {
    this.setState({
      inputSiteNameValue: evt.target.value
    });
  }

  handleClick(){
    if(!this.state.inputEngineUrlValue && !this.state.inputEngineUrlValue && !this.state.inputKeywordsValue)
      return;
    let url = 'api/Search/SearchSiteOccurences';
    let options = {
                method: 'POST',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json;charset=UTF-8'
                },
                body: JSON.stringify({
                    url: this.state.inputEngineUrlValue,
                    siteName: this.state.inputSiteNameValue,
                    keywords: this.state.inputKeywordsValue,
                })
            };
            
    fetch(url, options)
      .then(response => {
        const data = response.json();
    
        if(response.ok) 
        {
            return data;
        }
        const error = (data && data.message) || response.status;
        this.setState({ validationMsgs: true });
        return Promise.reject(error);
      })
      .then(data => {
        this.setState({ occurencesString: data, loading: false, validationMsgs: false });
      })
      .catch((status) => {
        console.log(status)
      });
   }

  render() {
    return (
      <div>
        <h1>Search Site Occurences</h1>
        <p>This component to retirve number of occurences of a site name when searching for certain keywords in a search engine.</p>
        {this.state.loading && <p><em>Loading...</em></p>}
        {!this.state.loading &&
        <table className='table'>
        <thead>
          <tr>
            <th>Occurences</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td>Enter Keywords to search for</td>
            <td><input id="keyowrds" type="text" required placeholder="keywords" value={this.inputKeywordsValue} onChange={this.updateInputKeywordsValue}/></td>
          </tr>
          <tr>
            <td>Enter Engine Url</td>
            <td><input id="url" type="text" required placeholder="google.com.au" value={this.inputEngineUrlValue} onChange={this.updateEngineUrlValue}/></td>
          </tr>
          <tr>
            <td>Enter Site Name</td>
            <td><input id="site" type="text" required placeholder="site name" value={this.inputSiteNameValue} onChange={this.updateSiteNameValue}/></td>
          </tr>
          <tr key="1">
            <td>
              Occurences
            </td>
              <td>{this.state.occurencesString.occurencesResult}</td>
          </tr>
          <tr>
            <td colSpan="2">
              <input type="button" value="Search" id="searchBtn" onClick={this.handleClick}/>
            </td>
          </tr>
        </tbody>
      </table>
      }
      </div>
    );
  }
}
