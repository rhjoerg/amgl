package ch.rhjoerg.amgl.content;

import java.io.File;
import java.io.InputStream;
import java.net.URI;
import java.net.http.HttpClient;
import java.net.http.HttpRequest;
import java.net.http.HttpResponse.BodyHandlers;
import java.nio.file.Files;
import java.nio.file.Path;
import java.util.Collections;
import java.util.SortedSet;
import java.util.TreeSet;
import java.util.zip.ZipEntry;
import java.util.zip.ZipFile;

import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;

import org.w3c.dom.Document;
import org.w3c.dom.Element;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;

public class Main
{
	private static HttpClient httpClient = HttpClient.newHttpClient();
	
	public static void main(String[] args) throws Exception
	{
		download("http://download.eclipse.org/technology/epp/packages/2021-03/compositeContent.xml");
		dax("http://download.eclipse.org/technology/epp/packages/2021-03/202103121200/content.jar");
				
		dax("http://download.eclipse.org/releases/2021-03/compositeContent.jar");
		dax("http://download.eclipse.org/releases/2021-03/202103171000/content.jar");
		
		units("downloads/download.eclipse.org/technology/epp/packages/2021-03/202103121200/content/content.xml");
		units("downloads/download.eclipse.org/releases/2021-03/202103171000/content/content.xml");
		
		dax("http://download.eclipse.org/technology/epp/packages/2021-03/202103121200/plugins/org.eclipse.epp.package.java_4.19.0.20210311-1200.jar");
		
		dax("http://download.eclipse.org/technology/epp/packages/2021-03/202103121200/binary/epp.package.committers.executable.win32.win32.x86_64_4.19.0.20210311-1200", ".zip");
		dax("http://download.eclipse.org/technology/epp/packages/2021-03/202103121200/binary/epp.package.java.executable.win32.win32.x86_64_4.19.0.20210311-1200", ".zip");
		
		dax("https://download.eclipse.org/releases/latest/compositeContent.jar");
		
		dax("https://download.eclipse.org/e4/snapshots/org.eclipse.e4.tools/latest/content.jar");
		units("downloads/download.eclipse.org/e4/snapshots/org.eclipse.e4.tools/latest/content/content.xml");
		
		dax("https://download.eclipse.org/eclipse/updates/4.19/compositeContent.jar");
		
		dax("https://download.eclipse.org/eclipse/updates/4.19/categories/content.jar");
		units("downloads/download.eclipse.org/eclipse/updates/4.19/categories/content/content.xml");
		
		dax("https://download.eclipse.org/eclipse/updates/4.19/R-4.19-202103031800/content.jar");
		units("downloads/download.eclipse.org/eclipse/updates/4.19/R-4.19-202103031800/content/content.xml");
		
		dax("https://download.eclipse.org/eclipse/updates/4.19/R-4.19-202103031800/binary/org.eclipse.sdk.ide.executable.win32.win32.x86_64_4.19.0.I20210303-1800", ".zip");
		
		dax("https://download.java.net/java/GA/jdk15.0.2/0d1cfde4252546c6931946de8db48ee2/7/GPL/openjdk-15.0.2_windows-x64_bin.zip");
	}
	
	private static Path path(String src) throws Exception
	{
		URI uri = new URI(src);
		
		return Path.of("downloads", uri.getHost(), uri.getPath());
	}
	
	private static void dax(String src, String ext) throws Exception
	{
		download(src, ext);
		extract(src + ext);
	}
	
	private static void dax(String src) throws Exception
	{
		dax(src, "");
	}
	
	private static Path download(String src, String ext) throws Exception
	{
		Path path = path(src + ext);
		
		if (Files.exists(path))
			return path;
		
		Files.createDirectories(path.getParent());
		httpClient.send(HttpRequest.newBuilder(new URI(src)).GET().build(), BodyHandlers.ofFile(path));
		
		return path;
	}
	
	private static Path download(String src) throws Exception
	{
		return download(src, "");
	}
	
	private static void extract(String src) throws Exception
	{
		Path folder = folder(src);
		Path path = path(src);
		
		try (ZipFile zip = new ZipFile(path.toFile()))
		{
			for (ZipEntry entry : Collections.list(zip.entries()))
			{
				if (entry.getName().endsWith("/"))
					continue;
				
				try (InputStream is = zip.getInputStream(entry))
				{
					Path out = folder.resolve(entry.getName());
					
					if (Files.exists(out))
						continue;
					
					Path parent = out.getParent();
					
					if (!Files.exists(parent))
						Files.createDirectories(out.getParent());
					
					Files.copy(is, out);
				}
			}
		}
	}
	
	private static Path folder(String src) throws Exception
	{
		return path(src.substring(0, src.lastIndexOf('.')));
	}
	
	private static void units(String src) throws Exception
	{
		DocumentBuilderFactory dbf = DocumentBuilderFactory.newInstance();
		DocumentBuilder db = dbf.newDocumentBuilder();
		Document doc = db.parse(new File(src));
		NodeList elems = doc.getElementsByTagName("unit");
		SortedSet<String> units = new TreeSet<>();
		
		for (int i = 0, n = elems.getLength(); i < n; ++i)
		{
			Node node = elems.item(i);
			Element element = (Element) node;
			String id = element.getAttribute("id");
			
			units.add(id);
		}
		
		Files.write(Path.of(src + ".txt"), units);
	}
}
