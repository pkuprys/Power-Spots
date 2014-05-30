using System.Collections;
using System;
using UnityEngine;
using Parse;

public class ParseUtil {
   	public static DateTime? GetLatestTime(ParseObject po, DateTime? dateTime){
		return po.UpdatedAt > dateTime || dateTime == null ? po.UpdatedAt : dateTime;
	}
}
