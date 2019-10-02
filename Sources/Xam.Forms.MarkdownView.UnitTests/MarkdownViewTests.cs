using System.Linq;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Xamarin.Forms;
using Xamarin.Forms.Mocks;

namespace Xam.Forms.MarkdownView.UnitTests
{
    [TestFixture]
    public class MarkdownViewTests : MarkdownView
    {
        [SetUp]
        public virtual void Init()
        {
            MockForms.Init();
        }
        
        [Test]
        public void test_markdown_urls()
        {
            var view = new MarkdownView();
            
            const string mardownText = "[This is a test url](https://www.google.com)";

            view.Markdown = mardownText;

            var hasLinks = view.Content.LogicalChildren.Any(x => x is Label label && label.GestureRecognizers.Any());
            Assert.IsTrue(hasLinks);
        }
        
        [Test]
        public void test_non_markdown_urls()
        {
            var view = new MarkdownView();
            
            const string mardownText = "https://www.google.com";

            view.Markdown = mardownText;

            var hasLinks = view.Content.LogicalChildren.Any(x => x is Label label && label.GestureRecognizers.Any());
            Assert.IsTrue(hasLinks);
        }
        
        [Test]
        public void test_no_urls()
        {
            var view = new MarkdownView();
            
            const string mardownText = "Regular test";

            view.Markdown = mardownText;

            var hasLinks = view.Content.LogicalChildren.Any(x => x is Label label && label.GestureRecognizers.Any());
            Assert.IsFalse(hasLinks);
        }
        
        [Test]
        public void test_phone_markdown_url()
        {
            var view = new MarkdownView();
            
            const string mardownText = "[Call me](tel:555-123-4567)";

            view.Markdown = mardownText;

            var hasLinks = view.Content.LogicalChildren.Any(x => x is Label label && label.GestureRecognizers.Any());
            Assert.IsTrue(hasLinks);
        }
        
        [Test]
        public void test_phone_no_url()
        {
            var view = new MarkdownView();
            
            const string mardownText = "555-123-4567";

            view.Markdown = mardownText;

            var hasLinks = view.Content.LogicalChildren.Any(x => x is Label label && label.GestureRecognizers.Any());
            Assert.IsFalse(hasLinks);
        }
        
        [Test]
        public void test_email_markdown_url()
        {
            var view = new MarkdownView();
            
            const string mardownText = "[Email me](test@null.io)";

            view.Markdown = mardownText;

            var hasLinks = view.Content.LogicalChildren.Any(x => x is Label label && label.GestureRecognizers.Any());
            Assert.IsTrue(hasLinks);
        }

        [Test]
        public void test_email_no_url()
        {
            var view = new MarkdownView();
            
            const string mardownText = "test@null.io";

            view.Markdown = mardownText;

            var hasLinks = view.Content.LogicalChildren.Any(x => x is Label label && label.GestureRecognizers.Any());
            Assert.IsFalse(hasLinks);
        }
    }
}