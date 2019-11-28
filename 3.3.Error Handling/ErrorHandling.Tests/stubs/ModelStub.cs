
using System;
using System.Collections;
using System.Collections.Generic;
using ErrorHandling.Task1.ThirdParty;

public class ModelStub :IModel {

    private IDictionary<string,string> attributes = new Dictionary<string, string>();

    public void AddAttribute(string name, string s) {
        attributes.Add(name, s);
    }

    
    public string GetAttribute(string name) {
        return attributes[name];
    }
}
